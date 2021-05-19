using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryScreen;

    private void Start()
    {
        HideMouse();
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
