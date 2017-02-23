using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform target;//цель

    public float cameraOffsetX;//сдвиг камеры по Х
    public float cameraOffsetY;//сдвиг камеры по У

    void Update()
    {
        if (target)
        {
            transform.position = new Vector3(target.position.x + cameraOffsetX, target.position.y + cameraOffsetY, -90f);
        }
    }
}
