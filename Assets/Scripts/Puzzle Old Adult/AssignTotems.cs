using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignTotems : MonoBehaviour
{
    [SerializeField] private GameObject equippedTotem;
    internal GameObject totemInstantiated;
    internal bool totemEquipped = false;

    public void PickTotem(Totem totem)
    {
        totemInstantiated = Instantiate(totem.gameObject, equippedTotem.transform.position, 
                                                equippedTotem.transform.rotation ,equippedTotem.transform);
        totemInstantiated.GetComponent<Totem>().isChild = true;
        totemEquipped = true;
    }

    public void DropTotem()
    {
        Destroy(totemInstantiated);
        totemEquipped = false;
    }

    public void GiveTotem(GameObject parentToGive)
    {
        if(totemInstantiated != null)
        {
            totemInstantiated.transform.SetParent(parentToGive.transform);
            totemInstantiated.transform.localPosition = Vector3.zero;
            totemInstantiated.transform.localRotation = Quaternion.identity;
            totemEquipped = false;
        }
    }

    public void ReceiveTotemAnswered(GameObject AnswerReceived)
    {
        totemInstantiated = Instantiate(AnswerReceived, equippedTotem.transform.position, 
                    equippedTotem.transform.rotation, equippedTotem.transform);
        totemEquipped = true;
    }
}
