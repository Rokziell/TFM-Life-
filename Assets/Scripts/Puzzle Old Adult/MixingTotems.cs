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
    
    public void MixTotems()
    {
        caseNumber = totem1.GetComponentInChildren<Totem>().GetColor() + totem2.GetComponentInChildren<Totem>().GetColor();
        switch (caseNumber)
        {
            case 0: 
                Debug.Log("caso1");
                break;
            case 1:
                Debug.Log("caso2");
                break;
            case 2:
                Debug.Log("caso3");
                break;
            case 3:
                Debug.Log("caso4");
                break;
            case 4:
                Debug.Log("caso5");
                break;
            case 5:
                Debug.Log("caso6");
                break;
            case 6:
                Debug.Log("caso7");
                break;
            case 7:
                Debug.Log("caso8");
                break;
            case 8:
                Debug.Log("caso9");
                break;
            case 9:
                Debug.Log("caso10");
                break;
            case 10:
                Debug.Log("caso11");
                break;
            default:
                Debug.Log("caso base");
                break;
        }
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
