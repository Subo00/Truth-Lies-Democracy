using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    private Collider2D myCollider;
    private float maxColliderScale = 0.7f;
    private float minColliderScale = 0.5f;


    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }


    public void ScaleColliderCapture(float scale = 0f)
    {
        if (scale == 0f) scale = maxColliderScale;
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
