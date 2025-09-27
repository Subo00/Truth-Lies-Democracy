using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private Camera cam;
    [SerializeField] private int raysX = 5;
    [SerializeField] private int raysY = 4;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float cameraWidth = 360f;
    [SerializeField] private float cameraHeight = 180f;


    private Texture2D screenCapture;
    private bool viewPhoto; //remove this (lol)

    
    

    private void Start()
    {
        //screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenCapture = new Texture2D((int)cameraWidth, (int)cameraHeight, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        CastRayGrid();
        if (Input.GetMouseButtonDown(0))
        {
            if (viewPhoto)
            {
                RemovePhoto();
            }
            else
            {
                StartCoroutine(CapturePhoto());

            }
        }
    }

    IEnumerator CapturePhoto()
    {
        viewPhoto = true;

        yield return new WaitForEndOfFrame();

        int xPos = (int)Input.mousePosition.x - (int)cameraWidth / 2;
        int yPos = (int)Input.mousePosition.y - (int)cameraHeight / 2;

        //TODO change this rect to captureo only the part of the screen not the full screen
        //Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        Rect regionToRead = new Rect(xPos, yPos, cameraWidth, cameraHeight);
        CastRayGrid();

        
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();

        ShowPhoto();
    }

    private void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoFrame.SetActive(true);
    }

    private void RemovePhoto()
    {
        viewPhoto = false;
        photoFrame.SetActive(false);
    }

    private void CastSingleRay()
    {
        RaycastHit2D[] hits;
        //first get the world coordinates of the current mouse position, taking into account the distance of the camera that is assumed to be negative Z
        Vector3 w = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -1 * Camera.main.transform.position.z));
        //Next we do a 2D raycast with with null direction and 0 length, this will collide as long as the world point above is inside one of your colliders
        hits = Physics2D.RaycastAll(new Vector2(w.x, w.y), (new Vector2(0f, 0f)).normalized * 0);

        foreach(var hit in hits)
        {
            Debug.Log("I hit " + hit.collider.gameObject.name);
        }

        /*Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit);
        if (hit.collider != null)
        {
            Debug.Log($" hit: {hit.collider.gameObject.name}");
            //hit.collider.gameObject.SetActive(false);
        }*/
    }
    private void CastRayGrid()
    {
        int xPos = (int)Input.mousePosition.x - (int)cameraWidth / 2;
        int yPos = (int)Input.mousePosition.y - (int)cameraHeight / 2;

        for (int x = 0; x < raysX; x++)
        {
            for(int y = 0; y < raysY; y++)
            {
                float u = (float)x / (raysX - 1);
                float v = (float)y / (raysY - 1);

                Vector3 screenPoint = new Vector3(u * cameraWidth + (float)xPos , v * cameraHeight  + (float)yPos, 0f);

                Ray ray = cam.ScreenPointToRay(screenPoint);

                Physics.Raycast(cam.transform.position, ray.direction,  out RaycastHit hit, maxDistance);

                Debug.DrawRay(cam.transform.position, ray.direction * maxDistance, Color.green);

                if (hit.collider != null)
                {
                    Debug.Log($"Ray ({x},{y}) hit: {hit.collider.gameObject.name}");
                    //hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}
