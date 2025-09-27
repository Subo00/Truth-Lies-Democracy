using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private Camera cam;
    private Texture2D screenCapture;
    private bool viewPhoto; //remove this (lol)

    
    private int raysX = 5;
    private int raysY = 4;
    private float maxDistance = 100f;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
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

        //TODO change this rect to captureo only the part of the screen not the full screen
        Rect regionToRead = new(0, 0, Screen.width, Screen.height);
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

    private void CastRayGrid()
    {
        int total = raysX * raysY;
        for(int x = 0; x < raysX; x++)
        {
            for(int y = 0; y < raysY; y++)
            {
                float u = (float)x / (raysX - 1);
                float v = (float)y / (raysY - 1);

                Vector3 screenPoint = new(u * Screen.width, v * Screen.height, 0f);

                Ray ray = cam.ScreenPointToRay(screenPoint);

                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, maxDistance);

                Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);

                if(hit.collider != null)
                {
                    Debug.Log($"Ray ({x},{y}) hit: {hit.collider.gameObject.name}");
                    //hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}
