using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryCanvas;
    [SerializeField] private GameObject victoryExit;

    private void Start()
    {
        HideMouse();
    }

    IEnumerator ExitDoor()
    {
        yield return new WaitForSeconds(1);
        ShowExit();

        yield return null;
    }

    public void ShowExit()
    {
        victoryExit.SetActive(true);
    }

    public void VictoryScreen()
    {
        victoryCanvas.SetActive(true);
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
