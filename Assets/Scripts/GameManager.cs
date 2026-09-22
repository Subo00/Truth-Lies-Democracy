using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class GameManager : MonoBehaviour
{
    public Assignment[] allAssignments;
    private Assignment currentAssigment;
    private Queue<Assignment> queuOfAssignments = new Queue<Assignment>();

    [SerializeField] private GameObject AssigmentPicker;
    [SerializeField] private AssigmentChoice[] assigmentChoices;

    private int numOffAssigments = 3;
    private Queue<Assignment> queueOfCompleted = new Queue<Assignment>();
    private Queue<Assignment> queueOfFaild = new Queue<Assignment>();

    private int maxEthics = 100;
    private int currentEthics;
    public int neededGold = 1500;
    public int currentGold = 0;

    private void Start()
    {

        currentEthics = maxEthics / 2;

        //AssigmentPicker.SetActive(true);

        /*for(int i = 0; i < 3; i++)
        {
            assigmentChoices[i].SetAssigment(allAssignments[i]);
        }*/
    }

    public void CheckValue(Dictionary<PointType, float> points)
    {
        bool isCompleted = true;

        if ( currentAssigment != null)
        {
            foreach (Goal goal in currentAssigment.goals)
            {
                if (points.TryGetValue(goal.pointType, out float value) == false || goal.neededValue > value)
                {
                    isCompleted = false;
                    break;
                }
            }


            if (isCompleted)
            {

                Debug.Log("You got paid " + currentAssigment.Reward + " gold");
                queueOfCompleted.Enqueue(currentAssigment);
                //add gold and remove assigment
            }
            else
            {
                Debug.Log("You get nothing, good day sir!");
                queueOfFaild.Enqueue(currentAssigment);
                //remove assigment
            }
        }
        

        if(queuOfAssignments.Count == 0)
        {
            AssigmentPicker.SetActive(true);
        }
        else
        {
            currentAssigment = queuOfAssignments.Dequeue();
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

    public void AddAssigments(Assignment assingment)
    {
        queuOfAssignments.Enqueue(assingment); 

        numOffAssigments--;

        if(numOffAssigments == 0)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        AssigmentPicker.SetActive(false);
        numOffAssigments = 3;
        currentAssigment = queuOfAssignments.Dequeue();
    }
    

    public Assignment GetCurrentAssignment()
    {
        return currentAssigment;
    }
    
    public int CheckAssignments(Assignment assignment)
    {
        if (queueOfCompleted.Contains(assignment)) return 0;
        if (queueOfFaild.Contains(assignment)) return 1;
        return 2;
    }

}
