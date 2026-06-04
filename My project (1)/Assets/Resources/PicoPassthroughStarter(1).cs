using UnityEngine;
using Unity.XR.PXR;

public class PicoPassthroughStarter : MonoBehaviour
{
    [SerializeField] private Camera xrCamera;

    private void Awake()
    {
        if (xrCamera == null)
        {
            xrCamera = Camera.main;
        }

        if (xrCamera != null)
        {
            xrCamera.clearFlags = CameraClearFlags.SolidColor;
            xrCamera.backgroundColor = new Color(0f, 0f, 0f, 0f);
        }
    }

    private void Start()
    {
        EnablePassthrough();
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            EnablePassthrough();
        }
    }

    private void EnablePassthrough()
    {
        PXR_Manager.EnableVideoSeeThrough = true;
    }
}