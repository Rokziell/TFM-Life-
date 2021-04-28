using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTeleporter : MonoBehaviour
{
    public Transform receiver;
    private bool playerIsOverlapping = false;

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 portalToPlayer = other.transform.position - transform.position;
            Debug.Log(playerIsOverlapping);

            float angleBetweenPlayerPortal = Vector3.SignedAngle(other.transform.forward, transform.forward, Vector3.up);
            if(angleBetweenPlayerPortal < 89 && angleBetweenPlayerPortal > -89)
            {
                 float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                other.transform.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;

                CharacterController charController = other.GetComponent<CharacterController>();

                charController.enabled = false;
                other.transform.position = receiver.position + positionOffset;
                charController.enabled = true;

                Debug.Log("Paso");

                playerIsOverlapping = false;
                
                Debug.Log(playerIsOverlapping);
            }
        }
    }
}
