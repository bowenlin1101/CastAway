using Cinemachine;
using UnityEngine;

public class VirtualCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;

    void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (virtualCamera.Follow == null)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                virtualCamera.Follow = player.transform;
            }
        }
    }
}
