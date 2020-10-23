using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int HealthPoints { set; get; }
    private TextMeshPro healthPointsCount;
    [SerializeField]
    private Gradient brickColor, brickColor2;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        healthPointsCount = GetComponentInChildren<TextMeshPro>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Show();
    }

    private void Show()
    {
        healthPointsCount.text = HealthPoints.ToString();
        if (HealthPoints < 200)
        {
            spriteRenderer.color = brickColor.Evaluate(HealthPoints / 200f);
        }
        else
        {
            spriteRenderer.color = brickColor2.Evaluate((HealthPoints - 200) / 1000f);
        }
    }
}
