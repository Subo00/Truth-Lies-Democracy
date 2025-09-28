using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


public enum PointType { None, Protester, Fire, Child, Adult, Police, Nature}
public class PointCounter : MonoBehaviour
{
    public static PointCounter Instance;
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

    private Dictionary<PointType, float> points = new Dictionary<PointType, float>();

    public void AddPoint(PointType type)
    {
        if(points.ContainsKey(type)) 
        {
            points[type] += 1f;
        }
        else
        {
            points.Add(type, 1f);

        }
    }

    public void ClearPoints()
    {
        points.Clear();
    }
    public void CheckWin()
    {
        GameManager.Instance.CheckValue(points);
    }
    public void PrintPoints()
    {
        foreach(var point in points)
        {
            //Debug.Log("type shit: " + point.Key + " value: " +point.Value);
        }
    }
}
