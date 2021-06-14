using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectMovement : MonoBehaviour
{
    internal bool isGrabbed;
    // Update is called once per frame
    void Update()
    {

    }

    public void StartMoving(Transform player, Vector3 direction)
    {
        Quaternion grabbingDirection = Quaternion.identity;
        if(player.rotation.eulerAngles.y < 45 && player.rotation.eulerAngles.y > 315)
        {
            grabbingDirection = Quaternion.Euler(player.rotation.eulerAngles .x, 0f, player.rotation.eulerAngles.z);
        } else if(player.rotation.eulerAngles.y < 135 && player.rotation.eulerAngles.y > 45)
        {
            grabbingDirection = Quaternion.Euler(player.rotation.eulerAngles.x, 90f, player.rotation.eulerAngles.z);
        } else if(player.rotation.eulerAngles.y < 225 && player.rotation.eulerAngles.y > 135)
        {
            grabbingDirection = Quaternion.Euler(player.rotation.eulerAngles.x, 180f, player.rotation.eulerAngles.z);
        } else if(player.rotation.eulerAngles.y < 315 && player.rotation.eulerAngles.y > 225)
        {
            grabbingDirection = Quaternion.Euler(player.rotation.eulerAngles.x, 270f, player.rotation.eulerAngles.z);
        }
        direction.Normalize();
        Vector3 newRotation = grabbingDirection * Vector3.forward;
        newRotation = newRotation * direction.z;

        // ObjectMovement(newRotation);
        // ForwardMove(newRotation);
        
        if(canMove)
        {
            StartCoroutine("MovementForward", newRotation);
        }
    }

    private float delay = 2f;
    public void ObjectMovement(Vector3 direction)
    {
        if(delay < Time.time)
        {
            delay += 2f;
            float velocity = 4f;
            GetComponent<Rigidbody>().position = transform.position + (new Vector3(direction.x, 0, direction.z) * velocity* Time.deltaTime);
        }

    }
    private bool canMove = true;
    IEnumerator MovementForward(Vector3 direction)
    {
        Debug.Log(direction);
        if(direction.magnitude == 1)
        {
            canMove = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(direction.x, 0, direction.z) * 5, ForceMode.Impulse);
            Debug.Log("me muevo leches");
            yield return new WaitForSeconds(1f);
         
            canMove = true;
        }
        yield return null;
    }

    public void ForwardMove(Vector3 direction)
    {
        if(delay < Time.time)
        {   
            delay += Time.time;
            GetComponent<Rigidbody>().AddForce(direction * 2, ForceMode.Impulse);
        }
    }
}
