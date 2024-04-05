using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    void Update()
    {
            transform.Translate(Vector3.left * GameManager.Instance.projectileSpeed * Time.deltaTime, Space.World);
    }
}

