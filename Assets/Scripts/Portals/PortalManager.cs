﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallChangeScene()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.ChangeScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CallChangeScene();
        }
    }
}
