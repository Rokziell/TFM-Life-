using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPuzzle : MonoBehaviour
{

    [SerializeField] private GameObject AnswerSpot;
    [SerializeField] private StartPuzzle puzzle;
    public Answers.AnswersList answerKey;
    private bool totemReceived = false;


    public bool CheckKeyReceived()
    {
        return totemReceived;
    }

    public void AssignKey(Answers.AnswersList KeyToAssign)
    {   
        answerKey = KeyToAssign;
    }

    public void CheckCorrectKey(AssignTotems player)
    {
        if(player.GetComponentInChildren<Answers>() != null)
        {
            if(answerKey.ToString() == player.GetComponentInChildren<Answers>().myAnswer.ToString())
            {
                totemReceived = true;
                player.GiveTotem(AnswerSpot);
                puzzle.OpenedLock(answerKey.GetHashCode());
            } else
            {
                Debug.Log("Mal");
            }
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(Input.GetButton("Interact"))
        {
            if(other.CompareTag("Player") && !totemReceived)
            {
                CheckCorrectKey(other.GetComponent<AssignTotems>());
                puzzle.CheckLocks();
            }
        }
    }

}
