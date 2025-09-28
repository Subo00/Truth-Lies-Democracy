using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Goal
{
    public PointType pointType;
    public float neededValue;
}

[System.Serializable]
public struct Statement
{
    public string text;
    public Goal[] goals;
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Statement[] statement;
    public bool isUIActive = false;

    public Statement currentStatement;
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

    public void CheckValue(Dictionary<PointType, float> points)
    {
        bool isWin = true;
        foreach(Goal goal in currentStatement.goals)
        {
            if (points.TryGetValue(goal.pointType, out float value) == false  || goal.neededValue > value)
            {
                isWin = false; 
                break;
            }
        }


        if (isWin)
        {
            Debug.Log("WIN");
        }
        else
        {
            Debug.Log("Try again!");
        }
    }
    

    
}
