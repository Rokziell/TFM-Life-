using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetupSet : MonoBehaviour
{
    [SerializeField] private Camera cameraChild;
    [SerializeField] private MeshRenderer rendererMatChild;

    void Start()
    {
        CameraTextureSize(cameraChild, rendererMatChild);

    }

    public void CameraTextureSize(Camera cameraToWork, MeshRenderer materialToWork)
    {
        if (cameraToWork.targetTexture != null)
        {
            cameraToWork.targetTexture.Release();
        }

        cameraToWork.targetTexture = new RenderTexture(Screen.width, Screen.height, 0);
        materialToWork.material.SetTexture("_MainTex", cameraToWork.targetTexture);
    }

    public void RenderCamera()
    {
    }
}
