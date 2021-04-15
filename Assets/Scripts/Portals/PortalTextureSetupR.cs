using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetupR : MonoBehaviour
{
    [SerializeField] private Camera cameraChildA;
    [SerializeField] private Material cameraMatChildA;
    [SerializeField] private Camera cameraChildB;
    [SerializeField] private Material cameraMatChildB;

    [SerializeField] private Camera cameraAdultA;
    [SerializeField] private Material cameraMatAdultA;
    [SerializeField] private Camera cameraAdultB;
    [SerializeField] private Material cameraMatAdultB;

    [SerializeField] private Camera cameraOlderA;
    [SerializeField] private Material cameraMatOlderA;
    [SerializeField] private Camera cameraOlderB;
    [SerializeField] private Material cameraMatOlderB;

    // Start is called before the first frame update
    void Start()
    {
        CameraTextureSize(cameraChildA, cameraMatChildA);
        CameraTextureSize(cameraAdultA, cameraMatAdultA);
        CameraTextureSize(cameraOlderA, cameraMatOlderA);

        CameraTextureSize(cameraChildB, cameraMatChildB);
        CameraTextureSize(cameraAdultB, cameraMatAdultB);
        CameraTextureSize(cameraOlderB, cameraMatOlderB);
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
