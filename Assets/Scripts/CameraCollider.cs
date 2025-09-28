using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    public static CameraCollider Instance;

    private Collider2D myCollider;
    private float maxColliderScale = 2f;
    private float minColliderScale = 1f;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition; 
        mousePos.z = -Camera.main.transform.position.z; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos); 
        transform.position = worldPos; 
    }
    public void ScaleColliderCapture(float scale = 2f)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    public void ScaleByLerp(float t)
    {
        float scaleValue = Mathf.Lerp(minColliderScale, maxColliderScale, t);
        ScaleColliderCapture(scaleValue);
    }

    public void CheckCollision()
    {
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = false; // ignore triggers unless you want them
        Collider2D[] results = new Collider2D[10]; // buffer

        int count = myCollider.OverlapCollider(filter, results);

        for (int i = 0; i < count; i++)
        {

            PointOfInterest poi = results[i].gameObject.GetComponent<PointOfInterest>();

            if (poi != null)
            {
                PointCounter.Instance.AddPoint(poi.pointType);
            }
        }
    }
}
