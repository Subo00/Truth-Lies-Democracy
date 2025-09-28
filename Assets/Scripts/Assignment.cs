using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;


[System.Serializable]
public struct Goal
{
    public PointType pointType;
    public float neededValue;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Assignment")]
public class Assignment : ScriptableObject
{
    [SerializeField]
    public int Id;
    public string MediaOutlet;
    public string Headline;
    public string Description;
    public float Reward; // € or $
    public int Ethics_On_Accept;
    public int Ethics_On_Reject;
    // public float TimeRemaining;
    public Goal[] goals;
    
}
