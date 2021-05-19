using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingTotems : MonoBehaviour
{
    [SerializeField] private GameObject totem1;
    [SerializeField] private GameObject totem2;
    [SerializeField] private GameObject finalTotem;
    private bool totemReceived = false;
    private bool totem1Received = false;
    private bool totem2Received = false;
    private int caseNumber;

    public void ReceiveTotem(GameObject totemReceived)
    {
        if(!totem1Received)
        {
            totemReceived.GetComponent<AssignTotems>().GiveTotem(totem1);
            totem1Received = true;
        } else if(!totem2Received)
        {
            totemReceived.GetComponent<AssignTotems>().GiveTotem(totem2);
            totem2Received = true;
            MixTotems();
        }
    }

    public void WrongMixing()
    {
        
        if(totem1.transform.childCount != 0)
        {
            Destroy(totem1.transform.GetChild(0).gameObject);
        }
        if(totem2.transform.childCount != 0)
        {
           Destroy(totem2.transform.GetChild(0).gameObject);
        }    
        ResetPuzzleBools();
    }

    public void ResetPuzzleBools()
    {
        totem1Received = false;
        totem2Received = false;
    }

    public void MixTotems()
    {
        int totemNumber1 = totem1.GetComponentInChildren<Totem>().assignColor.GetHashCode();
        int totemNumber2 = totem2.GetComponentInChildren<Totem>().assignColor.GetHashCode();
        caseNumber = totemNumber1 + totemNumber2;
        FindObjectOfType<StartPuzzle>().DesiredAnswer(caseNumber);
    }

    private void OnTriggerStay(Collider other) 
    {
        if(Input.GetButton("Interact"))
        {
            if(other.CompareTag("Player") && !totemReceived)
            {
                ReceiveTotem(other.gameObject);
                totemReceived = true;  
            }
        }    
    }
    private void OnTriggerExit(Collider other) 
    {
        totemReceived = false;    
    }
}
