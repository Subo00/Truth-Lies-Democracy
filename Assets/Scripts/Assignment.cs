
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
    public string MediaOutlet;
    public string Headline;
    public string Description;
    public string Explenation;
    public float Reward; // � or $
    public int Ethics_On_Accept;
    public int Ethics_On_Reject;
    // public float TimeRemaining;
    public Goal[] goals;
    
}
