using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPuzzle : MonoBehaviour
{

    [SerializeField] private GameObject[] totemColors;
    [SerializeField] private bool activePuzzle = false;
    [SerializeField] private float timeToEndPuzzle = 30.0f;

    public void ShowPuzzlePieces()
    {
        activePuzzle = true;
        for(int i = 0; i < totemColors.Length; i++)
        {
            totemColors[i].SetActive(true);
        }
        StartCoroutine("RestartPuzzle");
    }

    public void HidePuzzlePieces()
    {
        activePuzzle = false;
        for(int i = 0; i < totemColors.Length; i++)
        {
            totemColors[i].SetActive(false);
        }
        FindObjectOfType<AssignTotems>().DropTotem();
    }

    IEnumerator RestartPuzzle()
    {
        Debug.Log("RestartStart");
        yield return new WaitForSeconds(timeToEndPuzzle);
        
        Debug.Log("Restart");
        HidePuzzlePieces();
        yield return null;
    }


    private void OnTriggerStay(Collider other) 
    {
        if(Input.GetButton("Interact") && !activePuzzle)
        {    
            if(other.CompareTag("Player"))
            {
                ShowPuzzlePieces();
            }
        }
    }
}
