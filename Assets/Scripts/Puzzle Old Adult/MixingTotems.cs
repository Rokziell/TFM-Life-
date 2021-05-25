using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingTotems : MonoBehaviour
{
    [SerializeField] private GameObject totem1;
    [SerializeField] private GameObject totem2;
    [SerializeField] private StartPuzzle puzzle;
    private bool totemReceived = false;
    private bool totem1Received = false;
    private bool totem2Received = false;
    private string caseName;
    private Answers.AnswersList answerProvided;

    public void ReceiveTotem(GameObject totemReceived)
    {
        if(!totem1Received)
        {
            totemReceived.GetComponent<AssignTotems>().GiveTotem(totem1);
            totem1Received = true;
        } else if(!totem2Received)
        {
            totemReceived.GetComponent<AssignTotems>().GiveTotem(totem2);
            totem2Received = true;
            MixTotems();
        }
    }

    public void FinishMixing()
    {
        
        if(totem1.transform.childCount != 0)
        {
            Destroy(totem1.transform.GetChild(0).gameObject);
        }
        if(totem2.transform.childCount != 0)
        {
           Destroy(totem2.transform.GetChild(0).gameObject);
        }    
        ResetPuzzleBools();
    }

    public void ResetPuzzleBools()
    {
        totemReceived = false;
        totem1Received = false;
        totem2Received = false;
    }

    public void MixTotems()
    {
        string totemNumber1 = totem1.GetComponentInChildren<Totem>().assignColor.ToString();
        string totemNumber2 = totem2.GetComponentInChildren<Totem>().assignColor.ToString();
        caseName = totemNumber1 + totemNumber2;
        FindAnswer(caseName);
    }

    public void FindAnswer(string caseName)
    {
        Answers.AnswersList answerSelected;
        if(caseName == (Totem.Color.Red.ToString() + Totem.Color.Blue.ToString()) || 
        caseName == (Totem.Color.Blue.ToString() + Totem.Color.Red.ToString()))
        {
            answerSelected = Answers.AnswersList.Answer1;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        } 
        else if(caseName == (Totem.Color.Red.ToString() + Totem.Color.Yellow.ToString()) || 
        caseName == (Totem.Color.Yellow.ToString() + Totem.Color.Red.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer2;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        } 
        else if(caseName == (Totem.Color.Red.ToString() + Totem.Color.Green.ToString()) || 
        caseName == (Totem.Color.Green.ToString() + Totem.Color.Red.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer3;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Red.ToString() + Totem.Color.Orange.ToString()) || 
        caseName == (Totem.Color.Orange.ToString() + Totem.Color.Red.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer4;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Red.ToString() + Totem.Color.Purple.ToString()) || 
        caseName == (Totem.Color.Purple.ToString() + Totem.Color.Red.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer5;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Blue.ToString() + Totem.Color.Yellow.ToString()) || 
        caseName == (Totem.Color.Yellow.ToString() + Totem.Color.Blue.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer6;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Blue.ToString() + Totem.Color.Green.ToString()) || 
        caseName == (Totem.Color.Green.ToString() + Totem.Color.Blue.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer7;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Blue.ToString() + Totem.Color.Orange.ToString()) || 
        caseName == (Totem.Color.Orange.ToString() + Totem.Color.Blue.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer8;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Blue.ToString() + Totem.Color.Purple.ToString()) || 
        caseName == (Totem.Color.Purple.ToString() + Totem.Color.Blue.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer9;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Yellow.ToString() + Totem.Color.Green.ToString()) || 
        caseName == (Totem.Color.Green.ToString() + Totem.Color.Yellow.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer10;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Yellow.ToString() + Totem.Color.Orange.ToString()) || 
        caseName == (Totem.Color.Orange.ToString() + Totem.Color.Yellow.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer11;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Yellow.ToString() + Totem.Color.Purple.ToString()) || 
        caseName == (Totem.Color.Purple.ToString() + Totem.Color.Yellow.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer12;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Green.ToString() + Totem.Color.Orange.ToString()) || 
        caseName == (Totem.Color.Orange.ToString() + Totem.Color.Green.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer13;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Green.ToString() + Totem.Color.Purple.ToString()) || 
        caseName == (Totem.Color.Purple.ToString() + Totem.Color.Green.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer14;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
        else if(caseName == (Totem.Color.Orange.ToString() + Totem.Color.Purple.ToString()) || 
        caseName == (Totem.Color.Purple.ToString() + Totem.Color.Orange.ToString()))
        {   
            answerSelected = Answers.AnswersList.Answer15;
            puzzle.DesiredAnswer(answerSelected.GetHashCode());
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(Input.GetButton("Interact"))
        {
            if(other.CompareTag("Player") && !totemReceived)
            {
                if(other.GetComponent<AssignTotems>().totemEquipped)
                {
                    ReceiveTotem(other.gameObject);                
                    totemReceived = true;  
                }
            }
        }    
    }
    private void OnTriggerExit(Collider other) 
    {
        totemReceived = false;    
    }
    private void OnEnable() 
    {
        totemReceived = false;  
    }
}
