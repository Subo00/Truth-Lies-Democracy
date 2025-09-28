using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomer : MonoBehaviour
{
    private CameraCollider cameraCollider;
    
    [SerializeField] private float maxSize = 5f;
    [SerializeField] private float minSize = 3f;
    [SerializeField] private float zoomSpeed = 5f;

    private Camera cam;
    
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = maxSize;
        cameraCollider = CameraCollider.Instance;
        cameraCollider.ScaleColliderCapture();
    }

    // Update is called once per frame
    void Update()
    {
        float zoom = cam.orthographicSize;
        if(Input.mouseScrollDelta.y > 0)
        {
            zoom -= zoomSpeed * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            zoom += zoomSpeed * Time.deltaTime;
        }

        zoom = Mathf.Clamp(zoom, minSize, maxSize);

        cam.orthographicSize = zoom;
        float t = Mathf.InverseLerp(minSize, maxSize, zoom);

        cameraCollider.ScaleByLerp(t);
    }


}
