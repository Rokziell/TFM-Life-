using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    private bool moveUp;

    private void Start() 
    {
        StartCoroutine("Move");    
    }

    void Update()
    {
        AutoRotation();
    }

    public void AutoRotation()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed);
    }
    IEnumerator Move()
    {
        float timeBetweenChanges = .75f;
        float speed = 1;
        float timeElapsed = 0;

        if(moveUp)
        {
            timeElapsed = 0;
            while (timeElapsed < timeBetweenChanges)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            moveUp = false;
        } else
        {
            timeElapsed = 0;
            while (timeElapsed < timeBetweenChanges)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            moveUp = true;
        }
        yield return Move();
    }
}
