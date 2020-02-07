using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform playerTransform;
    public float offset = 1.0f;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Carolin").transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;
        temp.x += offset;

        transform.position = temp;
    }
}
