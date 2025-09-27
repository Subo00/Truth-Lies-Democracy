using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrameGO;
    [SerializeField] private GameObject MoverGO;
    [SerializeField] private Camera cam;

    [SerializeField] private int raysX = 5;
    [SerializeField] private int raysY = 4;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float cameraWidth = 360f;
    [SerializeField] private float cameraHeight = 180f;

    private GameManager gameManager;
    private PointCounter pointCounter;
    private Texture2D screenCapture;


    private void Start()
    {
        screenCapture = new Texture2D((int)cameraWidth, (int)cameraHeight, TextureFormat.RGB24, false);
        gameManager = GameManager.Instance;
        pointCounter = PointCounter.Instance;
        if(pointCounter == null || gameManager == null)
        {
            Debug.LogError("PointCounter or GameManager are missing in the scene");
        }
    }

    private void Update()
    {
        if (gameManager.isUIActive) { return; }
        //CastRayGrid();

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CapturePhoto());
        }
    }

    IEnumerator CapturePhoto()
    {
        gameManager.isUIActive = true;

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

        photoFrameGO.SetActive(true);
        MoverGO.SetActive(false);
    }

    private void RemovePhoto()
    {
        gameManager.isUIActive = false;
        photoFrameGO.SetActive(false);
        MoverGO.SetActive(true);
    }

    private void CastRayGrid()
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
