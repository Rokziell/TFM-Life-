using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip itemHighlight;
    [SerializeField] private AudioSource audioSource;
    
    private void Start() 
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void QuitGame() {
        Application.Quit();
    }

    public void HighlightMenu()
    {
        this.audioSource.PlayOneShot(this.itemHighlight);
    }

    public void PreventOverlap()
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }
}
