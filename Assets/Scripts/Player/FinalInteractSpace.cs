using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalInteractSpace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("InteractableObject"))
        {
            FindObjectOfType<GameManager>().ShowExit();
        }    
    }
}
