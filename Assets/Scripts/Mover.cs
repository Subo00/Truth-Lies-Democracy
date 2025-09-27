
using UnityEngine;

public enum Direction { Up, Down, Left, Right } 

public class Mover : MonoBehaviour
{
    
    [SerializeField] private float farRight;
    [SerializeField] private float farLeft;
    [SerializeField] private float farUp;
    [SerializeField] private float farDown;
    [SerializeField] private float speed = 5f;
    private float currentX = 0f;
    private float currentY = 0f;
    private bool movingLeft = false;
    private bool movingRight = false;
    private bool movingUp = false;
    private bool movingDown = false;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameManager.isUIActive) return;
        currentX = transform.position.x;
        currentY = transform.position.y;
        if(movingRight && currentX < farRight) { transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime; }
        if(movingLeft && currentX > farLeft) { transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime; }
        if(movingUp && currentY < farUp) { transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime; }
        if(movingDown && currentY > farDown) { transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime; }
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
