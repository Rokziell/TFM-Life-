using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraR : MonoBehaviour
{

    private Transform mainCamera;
    [SerializeField] private Transform portal;
    [SerializeField] private Transform otherPortal;

     void Start() 
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraPosition();
        CameraRotation();
    }

    public void CameraPosition()
    {
        Vector3 playerOffsetFromPortal = mainCamera.position - otherPortal.position;
        transform.position = portal.position + (portal.rotation * playerOffsetFromPortal);
        
    }

    public void CameraRotation()
    {
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * mainCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
