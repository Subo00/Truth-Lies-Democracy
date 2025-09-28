using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startPos;
    private GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        cam = Camera.main.gameObject;
        startPos = transform.position.x;
    }

    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
