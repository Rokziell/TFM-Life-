using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    internal bool isChild = false;
    internal int colorNumber;

    public enum Color
    {   
        Red,
        Blue,
        Yellow,
        Green,
        Orange,
        Purple
    }
    public Color assignColor = Color.Red;
    private void OnTriggerStay(Collider other) 
    {        
        if(Input.GetButton("Interact") && !isChild)
        {  
            if(other.CompareTag("Player") && !other.GetComponent<AssignTotems>().totemEquipped)
            {
                other.gameObject.GetComponent<AssignTotems>().PickTotem(this);
            }
        }    
    }
}
