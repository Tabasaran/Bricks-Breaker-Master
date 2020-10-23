using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBrick : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(Vector3.forward * Random.Range(0, 4) * 90);
        RectTransform rectTransform = GetComponentInChildren<RectTransform>();
        rectTransform.rotation = Quaternion.identity;
    }
}
