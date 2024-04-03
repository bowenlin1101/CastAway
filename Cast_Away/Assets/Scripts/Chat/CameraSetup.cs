using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraSetup : MonoBehaviour
{
    void Start()
    {
        if (ChatManager.Instance != null)
        {
            ChatManager.Instance.SetCanvasCamera(GetComponent<Camera>());
        }
    }
}
