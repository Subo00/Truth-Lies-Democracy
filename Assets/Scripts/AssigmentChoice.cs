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

    private void Start()
    {
        description.text = assigment.Headline;
        description.text += assigment.Reward + " €";
    }
   
    public void Accept()
    {
        if(assigment.Ethics_On_Accept < 0 )
        {
            GameManager.Instance.ChangeEthics(assigment.Ethics_On_Accept);
        }
        GameManager.Instance.AddAssigments(assigment);
        //gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        int result = GameManager.Instance.CheckAssignments(assigment);
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
    /*
    public void Decline()
    {
        GameManager.Instance.ChangeEthics(assigment.Ethics_On_Reject);
        GameManager.Instance.RemoveAssigment();

        gameObject.SetActive(false);
    }*/
}
