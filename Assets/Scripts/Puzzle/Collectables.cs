using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private GameObject doorToOpen;
    [SerializeField] private GameObject[] collectables;

    [SerializeField] private int maxAmount;
    [SerializeField] private int amountCollected;

    // Start is called before the first frame update
    void Start()
    {
        maxAmount = collectables.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCollectable(Collider collectable)
    {
        collectable.gameObject.SetActive(false);
        amountCollected++;
        if (amountCollected == maxAmount)
        {
            doorToOpen.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectables"))
        {
            CheckCollectable(other);
        }
    }
}
