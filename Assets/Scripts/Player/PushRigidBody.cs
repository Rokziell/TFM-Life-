using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRigidBody : MonoBehaviour
{
    private bool objectPicked = false;

    private GameObject objectToInteract;

    private void Update() 
    {
        CheckInteraction();    
    }

    public void CheckInteraction()
    {
        if(Input.GetButtonDown("Interact"))
        {
            GetComponentInParent<Player>().MoveWithObject(objectToInteract);
        }
        else if(Input.GetButtonUp("Interact"))
        {
            GetComponentInParent<Player>().MoveWithObject(null);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("InteractableObject"))
        {
            objectToInteract = other.gameObject;   
        }    
    }

    private void OnTriggerExit(Collider other) 
    {        
        if(other.CompareTag("InteractableObject"))
        {
            objectToInteract = null;   
            GetComponentInParent<Player>().MoveWithObject( null);
        }    
    }
}
