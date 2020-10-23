using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int HealthPoints { set; get; }
    private TextMeshPro healthPointsCount;
    private void Start()
    {
        healthPointsCount = GetComponentInChildren<TextMeshPro>();
        healthPointsCount.text = HealthPoints.ToString();
    }
}
