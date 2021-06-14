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

    IEnumerator BackToMainMenu()
    {
        gameManager.ChangeScene(sceneToGo);
        return null;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            Invoke("BackToMainMenu", 1);
        }    
    }

}
