using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomer : MonoBehaviour
{
    [SerializeField] private float maxFOW = 100f;
    [SerializeField] private float minFOW = 30f;
    [SerializeField] private float zoomSpeed = 5f;
    private Camera cam;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float zoom = cam.fieldOfView;
        if(Input.mouseScrollDelta.y > 0)
        {
            zoom -= zoomSpeed * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            zoom += zoomSpeed * Time.deltaTime;
        }

        zoom = Mathf.Clamp(zoom, minFOW, maxFOW);

        cam.fieldOfView = zoom;
    }
}
