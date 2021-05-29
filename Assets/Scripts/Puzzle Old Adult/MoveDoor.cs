using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private AudioClip[] movement;
    private AudioSource myAudioSource;
    private bool move = false;
    private bool playSound = false;


    [ContextMenu("Muevete")]
    public void StartMoving()
    {
        move = true;
        StartCoroutine("OpenDoor");
    }

    void Update()
    {
        if(move)
        {
            Move();
        }
    }

    public void Move()
    {
        if(transform.position.y > -5)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);

        }
    }

    IEnumerator OpenDoor()
    {
        playSound = true;
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.clip = movement[0];
        myAudioSource.Play();
        yield return new WaitForSeconds(movement[0].length);
        
        myAudioSource.clip = movement[1];
        myAudioSource.Play();
        yield return new WaitForSeconds(movement[1].length);
        
        myAudioSource.clip = movement[2];
        myAudioSource.Play();
        
        yield return null;
    }

    public void StartSound()
    {
        if(!playSound)
        {
            GetComponent<AudioSource>().clip = movement[0];
            GetComponent<AudioSource>().Play();
            playSound = true;
        }
    }

    public void LoopedSound()
    {
        playSound = false;
        if(!playSound)
        {
            GetComponent<AudioSource>().clip = movement[1];
            GetComponent<AudioSource>().Play();
            playSound = true;
        }
    }

    public void FinishSound()
    {        
        if(!playSound)
        {
            GetComponent<AudioSource>().clip = movement[2];
            GetComponent<AudioSource>().Play();
            playSound = true;
        }
    }
}
