using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    public bool[] color;
    internal bool isChild = false;
    internal int colorNumber;

    public int GetColor()
    {
        for(int i = 0; i < color.Length; i++)
        {
            if(color[i])
            {
                colorNumber = i;
            }
        }
        return colorNumber;
    }

    private void OnTriggerStay(Collider other) 
    {        
        if(Input.GetButton("Interact") && !isChild)
        {  
            if(other.CompareTag("Player") && !other.GetComponent<AssignTotems>().totemEquipped)
            {
                other.gameObject.GetComponent<AssignTotems>().PickTotem(gameObject);
            }
        }    
    }
}
