using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(0, 10)] public float smoothing;

    void Update()
    {
        if (!target)
            target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothedCamera = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        transform.position = smoothedCamera;
    }
}
