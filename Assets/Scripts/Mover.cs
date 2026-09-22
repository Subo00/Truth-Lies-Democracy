
using UnityEngine;

public enum Direction { Up, Down, Left, Right } 

public class Mover : MonoBehaviour
{
    [Header("Camera movement")]
    [SerializeField] private float farRight;
    [SerializeField] private float farLeft;
    [SerializeField] private float farUp;
    [SerializeField] private float farDown;
    [SerializeField] private float speed = 5f;

    [Header("Camera zoom")]
    [SerializeField] private float startSize = 5f;
    [SerializeField] private float maxSize = 5.4f;
    [SerializeField] private float minSize = 3f;
    [SerializeField] private float zoomSpeed = 5f;

    private float currentRightBorder;
    private float currentLeftBorder;
    private float currentUpBorder;
    private float currentDownBorder;

    private float currentX = 0f;
    private float currentY = 0f;
    private bool movingLeft = false;
    private bool movingRight = false;
    private bool movingUp = false;
    private bool movingDown = false;

    private CameraCollider cameraCollider;

    private Camera cam;
    private void Start()
    {
        currentRightBorder = farRight;
        currentLeftBorder = farLeft;
        currentUpBorder = farUp;
        currentDownBorder = farDown;

        cam = GetComponent<Camera>();
        cam.orthographicSize = startSize;
        cameraCollider = GetComponentInChildren<CameraCollider>();
        cameraCollider.ScaleColliderCapture();

    }

    void Update()
    {
        doZoom();
        currentX = transform.position.x;
        currentY = transform.position.y;
        if(movingRight && currentX < currentRightBorder) 
        { 
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime; 
        }
        if(movingLeft && currentX > currentLeftBorder) 
        { 
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime; 
        }
        if(movingUp && currentY < currentUpBorder) 
        { 
            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime; 
        }
        if(movingDown && currentY > currentDownBorder) 
        { 
            transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }
    }
    

    void doZoom()
    {
        float zoom = cam.orthographicSize;
        if (Input.mouseScrollDelta.y > 0)
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
    public void Move(Direction dir)
    {
        switch (dir)
        {
            case Direction.Left:
                movingLeft = true;
                break;
            case Direction.Right:
                movingRight = true;
                break;
            case Direction.Up:
                movingUp = true;
                break;
            case Direction.Down:
                movingDown = true;
                break;
        }
    }

    public void MoveClear(Direction dir)
    {
        switch (dir)
        {
            case Direction.Left:
                movingLeft = false;
                break;
            case Direction.Right:
                movingRight = false;
                break;
            case Direction.Up:
                movingUp = false;
                break;
            case Direction.Down:
                movingDown = false;
                break;
        }
    }

}
