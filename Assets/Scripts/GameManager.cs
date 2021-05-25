using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject victoryExit;

    private void Start()
    {
        HideMouse();
    }

    public void ShowExit()
    {
        victoryExit.SetActive(true);
    }

    public void VictoryScreen()
    {
        ShowMouse();
        victoryScreen.SetActive(true);
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
