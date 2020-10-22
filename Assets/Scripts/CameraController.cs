using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = 2.465f / cam.aspect;
    }

}
