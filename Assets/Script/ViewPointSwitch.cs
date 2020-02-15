using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ViewPointSwitch : MonoBehaviour
{
    [SerializeField] private CameraSelection[] cameraSelection;

    private void Awake()
    {
        DisableAll();
        EnableCamera(cameraSelection[0]);
    }

    private void Update()
    {
        foreach (CameraSelection cameraSelected in cameraSelection)
        {
            if (cameraSelected.enable == true)
            {
                DisableAll();
                cameraSelected.enable = false;
                EnableCamera(cameraSelected);
            }
        }
    }

    public void EnableCamera(int num)
    {
        DisableAll();
        EnableCamera(cameraSelection[Mathf.Clamp(num, 0, cameraSelection.Length)]);
    }

    public void EnableCamera(string name)
    {
        name = name.ToLower();
        foreach (CameraSelection cameraSelected in cameraSelection)
        {
            if (cameraSelected.name.ToLower() == name)
            {
                DisableAll();
                EnableCamera(cameraSelected);
            }
        }
        Debug.LogWarning(name + " wasn't found.");
    }

    private void EnableCamera(CameraSelection cameraSelected)
    {
        cameraSelected.camera.enabled = true;
        cameraSelected.audioListener.enabled = true;
        cameraSelected.cinemachineBrain.enabled = true;
        cameraSelected.virtualCamera.enabled = true;
    }

    private void ToggleCamera(CameraSelection cameraSelected)
    {
        if (cameraSelected.camera.enabled == true)
        {
            cameraSelected.camera.enabled = false;
            cameraSelected.audioListener.enabled = false;
            return;
        }
        cameraSelected.camera.enabled = true;
        cameraSelected.audioListener.enabled = true;
    }

    private void DisableAll()
    {
        foreach (CameraSelection cameraSelected in cameraSelection)
        {
            cameraSelected.camera.enabled = false;
            cameraSelected.audioListener.enabled = false;
            cameraSelected.cinemachineBrain.enabled = false;
            cameraSelected.virtualCamera.enabled = false;
        }
    }
}

[System.Serializable]
public class CameraSelection
{
    public string name;
    public bool enable;
    public Camera camera;
    public AudioListener audioListener;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineBrain cinemachineBrain;
}
