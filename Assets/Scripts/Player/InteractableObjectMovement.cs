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
        Vector3 newRotation = grabbingDirection * Vector3.forward;
        newRotation = newRotation * direction.z;

        ObjectMovement(newRotation);
    }

    public void ObjectMovement(Vector3 direction)
    {
        float velocity = 4f;
        GetComponent<Rigidbody>().position = transform.position + (new Vector3(direction.x, 0, direction.z) * velocity* Time.deltaTime);

    }
}
