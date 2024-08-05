using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float cameraSmoothTime = 1;
    [SerializeField] bool lookAtPlayer = false;
    [SerializeField] int lowerLimit = -2;

    void Update()
    {
        if (player.transform.position.y > lowerLimit)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
        
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, cameraSmoothTime);

            if (lookAtPlayer)
            {
                transform.LookAt(player);
            }
        }
        
    }
}
