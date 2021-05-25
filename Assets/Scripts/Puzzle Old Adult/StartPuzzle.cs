using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject[] answerPrefab;
    [SerializeField] private GameObject answersLockParent;
    [SerializeField] private FinishPuzzle[] answersLocks;
    [SerializeField] private Totem[] totemColors;
    [SerializeField] private MixingTotems mixingTotems;
    [SerializeField] private bool activePuzzle = false;
    [SerializeField] private float timeToEndPuzzle = 30.0f;
    [SerializeField] private MoveDoor doorToOpen;
    private AssignTotems playerToAssignTotem;
    private GameManager gameManager;
    public Answers.AnswersList[] answersAmount;   
    private bool[] lockOpened;
    private bool puzzleFinished = false;
    public bool isLastPuzzle = false;


    private void Start() 
    {
        playerToAssignTotem = FindObjectOfType<AssignTotems>();
        gameManager = FindObjectOfType<GameManager>();
        CloseLocks();
        FindLocks();
        AssignLocks();
    }

    public void CloseLocks()
    {
        lockOpened = new bool[Answers.AnswersList.Answer15.GetHashCode() + 1];
        for(int i = 0; i < lockOpened.Length; i++)
        {
            lockOpened[i] = true;
        }
        for(int i = 0; i < answersAmount.Length; i++)
        {
            lockOpened[answersAmount[i].GetHashCode()] = false;
        }
    }

    public void FindLocks()
    {
        answersLocks = new FinishPuzzle[answersAmount.Length];
        for(int i = 0; i < answersLocks.Length;i++)
        {
            answersLocks[i] = answersLockParent.GetComponentsInChildren<FinishPuzzle>()[i];
        }
    }

    public void AssignLocks()
    {
        for(int i = 0; i < answersLocks.Length;i++)
        {
            answersLocks[i].AssignKey(answersAmount[i]);
        }
    }

    public void OpenedLock(int lockToOpen)
     {
        lockOpened[lockToOpen] = true;
     }

    public void ShowPuzzlePieces()
    {
        activePuzzle = true;
        for(int i = 0; i < totemColors.Length; i++)
        {
            totemColors[i].gameObject.SetActive(true);
        }
        mixingTotems.gameObject.SetActive(true);
        StartCoroutine("RestartPuzzle");
    }

    public void HidePuzzlePieces()
    {
        activePuzzle = false;
        playerToAssignTotem.DropTotem();
        mixingTotems.FinishMixing();
        for(int i = 0; i < totemColors.Length; i++)
        {
            totemColors[i].gameObject.SetActive(false);
        }
        mixingTotems.gameObject.SetActive(false);
    }

    IEnumerator RestartPuzzle()
    {
        yield return new WaitForSeconds(timeToEndPuzzle);
        Debug.Log("Restart");
        HidePuzzlePieces();
        yield return null;
    }
    public void RightAnswer(int answerCode)
    {
        StopCoroutine("RestartPuzzle");
        HidePuzzlePieces();
        playerToAssignTotem.ReceiveTotemAnswered(answerPrefab[answersAmount[answerCode].GetHashCode()]);
    }

    public void WrongAnswer()
    {
        mixingTotems.FinishMixing();
    }

    public void DesiredAnswer(int respuestaPlayer)
    {
        for(int i = 0; i < answersAmount.Length; i++)
        {
            if(respuestaPlayer == answersAmount[i].GetHashCode() && !lockOpened[answersAmount[i].GetHashCode()])
            {
                RightAnswer(i);
            }        
            if(respuestaPlayer != answersAmount[i].GetHashCode())
            {
                WrongAnswer();
            }        
        }
    }

    public void CheckLocks()
    {
        puzzleFinished = AllKeys();

        if(puzzleFinished)
        {
            doorToOpen.StartMoving();
            if(isLastPuzzle)
            {
                gameManager.ShowExit();
            }
        }
    }

    public bool AllKeys()
    {        
        for(int j = 0; j < answersLocks.Length; j++)
        {
            if(answersLocks[j].CheckKeyReceived())
            {

            } else
            {
                return false;
            }
        }
        return true;
    }

    private void OnTriggerStay(Collider other) 
    {
        if(Input.GetButton("Interact") && !activePuzzle && !puzzleFinished)
        {    
            if(other.CompareTag("Player") && !other.GetComponent<AssignTotems>().totemEquipped)
            {
                ShowPuzzlePieces();
            }
        }
    }
}
