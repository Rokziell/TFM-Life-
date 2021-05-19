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

    public void GiveTotem(GameObject mixTotem)
    {
        totemInstantiated.transform.SetParent(mixTotem.transform);
        totemInstantiated.transform.localPosition = Vector3.zero;
        totemInstantiated.transform.localRotation = Quaternion.identity;
        totemEquipped = false;
    }
}
