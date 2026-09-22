using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AssigmentChoice : MonoBehaviour
{
    public Assignment assigment;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image box;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.LogWarning("Could not find game manager!");
        }
        description.text = assigment.Headline;
        description.text += assigment.Reward + " €";
    }
   
    public void Accept()
    {
        if(assigment.Ethics_On_Accept < 0 )
        {
            gameManager.ChangeEthics(assigment.Ethics_On_Accept);
        }
        gameManager.AddAssigments(assigment);
    }

    private void OnEnable()
    {
        if (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
            
        }
        int result = gameManager.CheckAssignments(assigment);
        switch (result)
        {
            case 0:
                box.sprite = Resources.Load<Sprite>("Images/MenuAndUI/ClipboardStuff/kasterlDone");
                break;
            case 1:
                box.sprite = Resources.Load<Sprite>("Images/MenuAndUI/ClipboardStuff/Unbenannt");
                break;
            case 2:
                //Stays as is
                break;


        }
    }

}
