using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetupR : MonoBehaviour
{
    [SerializeField] private Camera cameraA;
    [SerializeField] private Material cameraMatA;

    [SerializeField] private Camera cameraB;
    [SerializeField] private Material cameraMatB;



    // Start is called before the first frame update
    void Start()
    {
        CameraTextureSize(cameraA, cameraMatA);
        CameraTextureSize(cameraB, cameraMatB);
    }

    public void CameraTextureSize(Camera cameraToWork, Material materialToWork)
    {
        if (cameraToWork.targetTexture != null)
        {
            cameraToWork.targetTexture.Release();
        }
        cameraToWork.targetTexture = new RenderTexture(Screen.width, Screen.height, 0);
        materialToWork.mainTexture = cameraToWork.targetTexture;
    }

    public void RenderCamera()
    {
    }
}
