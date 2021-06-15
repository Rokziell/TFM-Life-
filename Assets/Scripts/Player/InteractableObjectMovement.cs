using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectMovement : MonoBehaviour
{
    internal bool isGrabbed;
    private bool canMove = true;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float elapsedTime = 0f;
    [SerializeField] private float movement = 1f;
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
        Debug.Log(newRotation.magnitude);
        
        if(canMove && CanBoxMove(newRotation, 2f) && newRotation.magnitude != 0)
        {
            canMove = false;
            StartCoroutine("BoxAnimation", newRotation);
        }
    }

    [SerializeField] private LayerMask raycastCollision = new LayerMask();
    public bool CanBoxMove(Vector3 directionToMove, float rayCastSize)
    {
        Ray myRay = new Ray();
        RaycastHit myHit;
        Debug.DrawRay(transform.position, directionToMove, Color.red, rayCastSize);

        if(Physics.Raycast(transform.position, directionToMove, rayCastSize, raycastCollision))
        {
            return false;
        }
        return true;
    }
    IEnumerator BoxAnimation(Vector3 direction)
    {
        elapsedTime = 0;
        Vector3 initialPosition = transform.position;
        Vector3 finalPosition = transform.position + (new Vector3(direction.x, 0, direction.z) * movement);
        Debug.Log(initialPosition);
        Debug.Log(finalPosition);

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
}
