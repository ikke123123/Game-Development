using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public enum ViewType { overview, blueplayer, redplayer };

    [SerializeField] private CameraPosition[] cameraPositions = null;

    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        foreach (CameraPosition cameraPosition in cameraPositions)
        {
            if (Input.GetKeyDown(cameraPosition.keycode))
            {
                SwitchCameraPosition(cameraPosition);
                break;
            }
        }
    }

    private void SwitchCameraPosition(CameraPosition cameraPosition)
    {
        virtualCamera.Follow = cameraPosition.location;
        virtualCamera.LookAt = cameraPosition.location;
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = SelectVector3(cameraPosition.viewType);
    }

    private Vector3 SelectVector3(ViewType viewType)
    {
        switch (viewType)
        {
            case ViewType.blueplayer:
                return new Vector3(5, 5, -10); ;
            case ViewType.redplayer:
                return new Vector3(-5, 5, -10); ;
            case ViewType.overview:
                return new Vector3(0, 100, 45); ;
            default:
                return new Vector3(0, 10, 10);
        }
    }
}

[System.Serializable]
public class CameraPosition
{
    public Transform location;
    public CameraSwitch.ViewType viewType;
    public KeyCode keycode;
}
