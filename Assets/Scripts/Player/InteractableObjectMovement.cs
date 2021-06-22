using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectMovement : MonoBehaviour
{
    internal bool isGrabbed;
    private bool canMove = true;
    private Vector3 playerPos;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float elapsedTime = 0f;
    [SerializeField] private float movement = 1f;
    [SerializeField] private LayerMask raycastCollision = new LayerMask();

    public void StartMoving(Transform player, Vector3 direction)
    {
        Quaternion grabbingDirection = Quaternion.identity;
        if(player.rotation.eulerAngles.y < 45 && player.rotation.eulerAngles.y > 315)
        {
            grabbingDirection = Quaternion.Euler(0f, 0f, 0f);
        } else if(player.rotation.eulerAngles.y < 135 && player.rotation.eulerAngles.y > 45)
        {
            grabbingDirection = Quaternion.Euler(0f, 90f, 0f);
        } else if(player.rotation.eulerAngles.y < 225 && player.rotation.eulerAngles.y > 135)
        {
            grabbingDirection = Quaternion.Euler(0f, 180f, 0f);
        } else if(player.rotation.eulerAngles.y < 315 && player.rotation.eulerAngles.y > 225)
        {
            grabbingDirection = Quaternion.Euler(0f, 270f, 0f);
        }
        Vector3 newRotation = grabbingDirection * Vector3.forward;
        newRotation = newRotation * direction.z;
        
        if(canMove && CanBoxMove(newRotation, 1.35f) && newRotation.magnitude != 0 && !PlayerCollide(playerPos,newRotation))
        {
            canMove = false;
            StartCoroutine("BoxAnimation", newRotation);
        }
    }

    public bool CanBoxMove(Vector3 directionToMove, float rayCastSize)
    {
        bool boolToReturn = true;
        Vector3 startPosition = transform.position;
        if(directionToMove.z > 0.1 || directionToMove.z < -0.1)
        {
            startPosition.x++;
        }
        if(directionToMove.x > 0.1 || directionToMove.x < -0.1)
        {
            startPosition.z++;
        }

        Debug.DrawRay(transform.position, directionToMove, Color.blue, rayCastSize);
        Debug.DrawRay((startPosition + Vector3.up), directionToMove, Color.red, rayCastSize);
        Debug.DrawRay((startPosition + Vector3.down), directionToMove, Color.red, rayCastSize);


        if(Physics.Raycast(transform.position, directionToMove, rayCastSize, raycastCollision))
        {
            boolToReturn = false;
        } 
        if(Physics.Raycast(startPosition + Vector3.up, directionToMove, rayCastSize, raycastCollision))
        {
            boolToReturn = false;
        }
        if(Physics.Raycast(startPosition + Vector3.down, directionToMove, rayCastSize, raycastCollision))
        {
            boolToReturn = false;
        }

        if(directionToMove.z > 0.1 || directionToMove.z < -0.1)
        {
            startPosition.x -= 2;
        }
        if(directionToMove.x > 0.1 || directionToMove.x < -0.1)
        {
            startPosition.z -= 2;
        }
        
        Debug.DrawRay(startPosition + Vector3.up, directionToMove, Color.green, rayCastSize);
        Debug.DrawRay(startPosition + Vector3.down, directionToMove, Color.green, rayCastSize);

        if(Physics.Raycast(startPosition + Vector3.up, directionToMove, rayCastSize, raycastCollision))
        {
            boolToReturn = false;
        }
        if(Physics.Raycast(startPosition + Vector3.down, directionToMove, rayCastSize, raycastCollision))
        {
            boolToReturn = false;
        }

        return boolToReturn;
    }

    public bool PlayerCollide(Vector3 playerPosition, Vector3 raycastDirection)
    {
        Debug.DrawRay(playerPosition, raycastDirection, Color.blue, 1f);
        if(Physics.Raycast(playerPosition, raycastDirection, 2f, raycastCollision))
        {
            return true;
        }
        return false;
    }


    IEnumerator BoxAnimation(Vector3 direction)
    {
        elapsedTime = 0;
        Vector3 initialPosition = transform.position;
        Vector3 finalPosition = transform.position + (new Vector3(direction.x, 0, direction.z) * movement);

        while(elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, finalPosition, elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);

        elapsedTime = 0;
        canMove = true;
        yield return null;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            playerPos = other.transform.position;
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player"))
        {
            playerPos = other.transform.position;
        }
    }
}
