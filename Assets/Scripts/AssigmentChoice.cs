using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssigmentChoice : MonoBehaviour
{
    public Assignment assigment;
    [SerializeField] private TMP_Text description;

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
        gameObject.SetActive(false);
    }

    public void Decline()
    {
        GameManager.Instance.ChangeEthics(assigment.Ethics_On_Reject);
        GameManager.Instance.RemoveAssigment();

        gameObject.SetActive(false);
    }
}
