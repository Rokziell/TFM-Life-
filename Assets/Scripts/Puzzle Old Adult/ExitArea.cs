using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GameObject myCanvas;
    [SerializeField] private string sceneToGo;
    [SerializeField] private SceneManager scene;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void BackToMainMenu()
    {
        gameManager.ChangeScene(sceneToGo);
    }

    public void ShowCinematic()
    {
        myCanvas.SetActive(true);
    }

    public void FinishedLevel()
    {
        GameManager.LevelFinished();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("cinematc");
            FinishedLevel();
            Invoke("ShowCinematic", 1);
        }    
    }

}
