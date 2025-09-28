using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public bool isUIActive = false;

    public Assignment[] allAssignments;
    private Assignment currentAssigment;
    private List<Assignment> listOfAssignments;

    [SerializeField] private GameObject AssigmentPicker;
    [SerializeField] private AssigmentChoice[] assigmentChoices;

    private int numOffAssigments = 3;

    private int maxEthics = 100;
    private int currentEthics;
    public int neededGold = 1500;
    public int currentGold = 0;

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
        currentAssigment = allAssignments[0];
        //Debug.Log(currentAssigment.Headline);
        currentEthics = maxEthics / 2;

        isUIActive = true;
        AssigmentPicker.SetActive(true);
        for(int i = 0; i < 3; i++)
        {
            assigmentChoices[i].SetAssigment(allAssignments[i]);
        }
    }

    public void CheckValue(Dictionary<PointType, float> points)
    {
        bool isCompleted = true;
        foreach(Goal goal in currentAssigment.goals)
        {
            if (points.TryGetValue(goal.pointType, out float value) == false  || goal.neededValue > value)
            {
                isCompleted = false; 
                break;
            }
        }


        if (isCompleted)
        {
            Debug.Log("WIN");
        }
        else
        {
            Debug.Log("Try again!");
        }
    }
    
    public void ChangeEthics(int value)
    {
        currentEthics += value;
        currentEthics = Mathf.Clamp(currentEthics, 0, maxEthics);
        if(currentEthics == 0)
        {
            Debug.Log("YOU LOSE");
        }
    }

    public void AddAssigments(Assignment assingment, bool add = true)
    {
        if (add) { listOfAssignments.Add(assingment); }

        numOffAssigments--;

        if(numOffAssigments == 0)
        {
            AssigmentPicker.SetActive(false);
            isUIActive = false;
        }
    }
    
}
