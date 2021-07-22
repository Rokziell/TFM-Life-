using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryExit;
    [SerializeField] private int maxLevels;
    public static int levelFinished = 0;

    private void Start()
    {
        HideMouse();
        CheckFinishedLevel();
    }

    public void CheckFinishedLevel()
    {   
        Debug.Log(GameManager.levelFinished);
        if(levelFinished == maxLevels)
        {
            ShowExit();
        }
    }
    
    public static void LevelFinished()
    {
        GameManager.levelFinished++;
    }

    public void ShowExit()
    {
        victoryExit.SetActive(true);
    }

    public void ChangeScene(string sceneToGo)
    {
        SceneManager.LoadScene(sceneToGo);
    }

    public void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
