using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PointType { Protester, Fire, Child, Adult, Police, Nature, Size}
public class PointCounter : MonoBehaviour
{
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
        foreach(var point in  points)
        {
            GameManager.Instance.CheckValue(point.Key, point.Value);
        }
    }
    public void PrintPoints()
    {
        foreach(var point in points)
        {
            Debug.Log("type shit: " + point.Key + " value: " +point.Value);
        }
    }
}
