using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject[] answerPrefab;
    [SerializeField] private Totem[] totemColors;
    [SerializeField] private MixingTotems mixingTotems;
    private GameObject myPlayer;
    [SerializeField] private bool activePuzzle = false;
    [SerializeField] private float timeToEndPuzzle = 30.0f;


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
        FindObjectOfType<AssignTotems>().DropTotem();
        FindObjectOfType<MixingTotems>().WrongMixing();
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
    public void RightAnswer()
    {
        Debug.Log("Right");
        myPlayer = GameObject.FindGameObjectWithTag("EquippedTotem");
        Instantiate(answerPrefab[answers.GetHashCode()], myPlayer.transform.position, myPlayer.transform.rotation, myPlayer.transform);
        StopCoroutine("RestartPuzzle");
        HidePuzzlePieces();

    }

    public void DesiredAnswer(int respuestaPlayer)
    {
        if(respuestaPlayer == answers.GetHashCode())
        {
            RightAnswer();
        }        
        if(respuestaPlayer != answers.GetHashCode())
        {
            Debug.Log("Wrong");
        }        
    }

    public enum Answers
    {
        Answer1,
        Answer2,
        Answer3,
        Answer4,
        Answer5,
        Answer6,
        Answer7,
        Answer8,
        Answer9,
        Answer10,
        Answer11,
    }
    public Answers answers = Answers.Answer1;

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
