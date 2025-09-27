using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Statement
{
    public string text;
    public PointType pointType;
    public float neededValue;
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Statement[] statement;
    public bool isUIActive = false;

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

    private void Start()
    {
        Debug.Log(statement[0].text);
    }

    public void CheckValue(PointType pointType, float neededValue)
    {
        if (statement[0].pointType == pointType && statement[0].neededValue < neededValue)
        {
            Debug.Log("WIN");
        }
        else
        {
            Debug.Log("Try again!");
        }
    }
    

    
}
