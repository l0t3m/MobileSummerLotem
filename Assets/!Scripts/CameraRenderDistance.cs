using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRenderDistance : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    private float minClippingPlane = 20f;
    private float maxClippingPlane = 50f;

    void Update()
    {
        UpdateClipping();
    }

    private void UpdateClipping()
    {
        float zAcceleration = Input.acceleration.z;
        float newClippingPlane = Mathf.Lerp(maxClippingPlane, minClippingPlane, 1 + Mathf.Clamp(zAcceleration, -1f, 0f));
        
        mainCamera.farClipPlane = newClippingPlane;
        Debug.Log($"Z-Acceleration: {zAcceleration}, Clipping Plane: {newClippingPlane}");
    }
}
