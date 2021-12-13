using System;
using UnityEngine;

public class CameraOrientation : MonoBehaviour
{
    public GameObject cameraObject;
    private Camera cameraInstance;
    private ScreenOrientation currentScreenOrientation;

    void Start()
    {
        cameraInstance = cameraObject.GetComponent<Camera>();
        currentScreenOrientation = Screen.orientation;
        AdjustCameraFOV();
    }

    void Update()
    {
        if (Screen.orientation != currentScreenOrientation)
            AdjustCameraFOV();
    }

    private void AdjustCameraFOV()
    {
        currentScreenOrientation = Screen.orientation;
        if (currentScreenOrientation == ScreenOrientation.LandscapeLeft || currentScreenOrientation == ScreenOrientation.LandscapeLeft || currentScreenOrientation == ScreenOrientation.LandscapeRight)
            cameraInstance.fieldOfView = 42;
        if (currentScreenOrientation == ScreenOrientation.Portrait || currentScreenOrientation == ScreenOrientation.PortraitUpsideDown)
            cameraInstance.fieldOfView = 70;
    }
}
