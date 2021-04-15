using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraR : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform portal;
    [SerializeField] private Transform otherPortal;
    [SerializeField] private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosition();
        CameraRotation();
    }

    public void CameraPosition()
    {
        var mainCameraPos = mainCamera.localToWorldMatrix.GetColumn(3);
        Vector3 playerOffsetFromPortal = mainCameraPos - otherPortal.localToWorldMatrix.GetColumn(3);
        transform.position = portal.position + playerOffsetFromPortal;
    }

    public void CameraRotation()
    {
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * mainCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
