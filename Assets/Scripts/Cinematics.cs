using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cinematics : MonoBehaviour
{
    [SerializeField] private Image myImage;
    [SerializeField] private Sprite[] imageToPlay;
    [SerializeField] private float duration = 5f;
    private int currentImage = 0;

    private void Start() 
    {
        StartCinematic();    
    }

    public void StartCinematic()
    {
        myImage.sprite = imageToPlay[currentImage];
        currentImage++;
        Invoke("ChangeCinematic", duration);
        Debug.Log("start");
    }
    public void ChangeCinematic()
    {
        if(currentImage < imageToPlay.Length)
        {
            myImage.sprite = imageToPlay[currentImage];
            currentImage++;
            Debug.Log("nextImage");
            Invoke("ChangeCinematic", duration);
        } else
        {
            Debug.Log("finish");
            FinishCinematic();
        }
    }

    public void FinishCinematic()
    {  
        FindObjectOfType<ExitArea>().BackToMainMenu();
    }
}
