using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAtBottom : MonoBehaviour
{
    public Camera uiCamera; // Assign the camera in the inspector, if null, main camera is used
    public float offsetFromBottom = 0.1f; // Offset from the bottom of the screen

    void Update()
    {
        if (uiCamera == null)
        {
            uiCamera = Camera.main; // Fallback to main camera if uiCamera is not assigned
        }

        // Calculate the position at the bottom of the screen, with a small offset
        Vector3 bottomCenterPosition = uiCamera.ViewportToWorldPoint(new Vector3(0.5f, offsetFromBottom, uiCamera.nearClipPlane));

        // Set the dialog box's position
        // Assuming the dialog's pivot is centered, otherwise adjust accordingly
        transform.position = new Vector3(transform.position.x, bottomCenterPosition.y, transform.position.z);
    }
}
