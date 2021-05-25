using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private string sceneToGo;
    [SerializeField] private SceneManager scene;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void PlayPortalSound()
    {

    }

    public void BackToMainMenu()
    {
        gameManager.ChangeScene(sceneToGo);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            BackToMainMenu();
        }    
    }

}
