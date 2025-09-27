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
    public Statement statement;


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
        Debug.Log(statement.text);
    }

    public void CheckValue(PointType pointType, float neededValue)
    {
        if(statement.pointType == pointType && statement.neededValue < neededValue)
        {
            Debug.Log("WIN");
        }
        else
        {
            Debug.Log("Try again!");
        }
    }
    
}
