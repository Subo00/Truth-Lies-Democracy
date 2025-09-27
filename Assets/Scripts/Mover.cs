
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float farRight;
    [SerializeField] private float farLeft;
    [SerializeField] private float speed = 5f;
    private float currentX = 0f;
    private bool movingLeft = false;
    private bool movingRight = false;
   

    // Update is called once per frame
    void Update()
    {
        currentX = transform.position.x;
        if(movingRight && currentX < farRight) { transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime; }
        if(movingLeft && currentX > farLeft) { transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime; }
    }

    public void MoveLeft()
    {
        movingLeft = true;
    }

    public void MoveRight()
    {
        movingRight = true;
    }

    public void MoveClear()
    {
        movingLeft = false;
        movingRight = false;
    }
}
