using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Statment
{
    public string text;
    public PointType pointType;
    public float neededValue;
}



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Statment statment;
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
    

    public void CheckValue(PointType type, float value)
    {
        if(statment.pointType == type && statment.neededValue < value)
        {
            Debug.Log("WIN");
        }else{
            Debug.Log("Try again!");
        }
    }
}
