using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]


    [SerializeField] private float cameraWidth = 360f;
    [SerializeField] private float cameraHeight = 180f;



    [SerializeField] private PhotoConfirmer photoConfirmer;
    [SerializeField] private UnityEvent onPhotoTaken;

    private PointCounter pointCounter;
    private Texture2D photoTexture;
    private AudioSource clickSound;
    private bool isTakingPhoto;
    private Camera camToTakePhotoFrom;

    private void Start()
    {
        camToTakePhotoFrom = Camera.main;
        clickSound = GetComponent<AudioSource>();
        photoTexture = new Texture2D((int)cameraWidth, (int)cameraHeight, TextureFormat.RGB24, false);
        pointCounter = PointCounter.Instance;
        if(pointCounter == null)
        {
            Debug.LogError("PointCounter missing in the scene");
        }
        Camera.onPostRender += OnPostRenderCallback;
    }

    void OnDestroy()
    {
        Camera.onPostRender -= OnPostRenderCallback;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            isTakingPhoto = true;
            //Debug.Log($"Screen: {Screen.width}x{Screen.height}, camera: {cameraWidth}x{cameraHeight}");

        }
    }


   void OnPostRenderCallback(Camera cam)
    {
        if (isTakingPhoto)
        {
            // Check whether the Camera that just finished rendering is the one you want to take a screen grab from
            if (cam == camToTakePhotoFrom)
            {
                // Define the parameters for the ReadPixels operation
                Rect regionToReadFrom = new Rect(0, 0, Screen.width, Screen.height);
                int xPosToWriteTo = 0;
                int yPosToWriteTo = 0;
                bool updateMipMapsAutomatically = false;

                // Copy the pixels from the Camera's render target to the texture
                photoTexture.ReadPixels(regionToReadFrom, xPosToWriteTo, yPosToWriteTo, updateMipMapsAutomatically);
                // Upload texture data to the GPU, so the GPU renders the updated texture
                photoTexture.Apply();

                photoConfirmer.currentPhoto = Sprite.Create(photoTexture, new Rect(0.0f, 0.0f, photoTexture.width, photoTexture.height), new Vector2(0.5f, 0.5f), 100.0f);

                onPhotoTaken.Invoke();
                isTakingPhoto = false;
            }

        }
    }

    private void RemovePhoto()
    {
        photoTexture.Reinitialize((int)cameraWidth, (int)cameraHeight);
        photoTexture.Apply();
    }

   /* private void CastRayGrid()
    {
        int xPos = (int)Input.mousePosition.x - (int)cameraWidth / 2;
        int yPos = (int)Input.mousePosition.y - (int)cameraHeight / 2;

        for (int x = 0; x < raysX; x++)
        {
            for (int y = 0; y < raysY; y++)
            {
                float u = (float)x / (raysX - 1);
                float v = (float)y / (raysY - 1);

                Vector3 screenPoint = new Vector3(u * cameraWidth + (float)xPos, v * cameraHeight + (float)yPos, 0f);

                Ray ray = cam.ScreenPointToRay(screenPoint);

                Physics.Raycast(cam.transform.position, ray.direction, out RaycastHit hit, maxDistance);

                Debug.DrawRay(cam.transform.position, ray.direction * maxDistance, Color.green);

                if (hit.collider != null)
                {
                    //Debug.Log($"Ray ({x},{y}) hit: {hit.collider.gameObject.name}");
                    //Debug.Log($"Ray ({x},{y}) hit: {hit.collider.gameObject.name}");

                    PointOfInterest poi = hit.collider.gameObject.GetComponent<PointOfInterest>();

                    if (poi != null)
                    {
                        pointCounter.AddPoint(poi.pointType);
                    }
                    //hit.collider.gameObject.SetActive(false);
                }
            }
        }
        pointCounter.PrintPoints();
    }
   */
    public void SendPicture()
    {
        pointCounter.CheckWin();
        pointCounter.ClearPoints();
        RemovePhoto();
    }

    public void DiscaredPicture()
    {
        pointCounter.ClearPoints();
        RemovePhoto();
    }
}
