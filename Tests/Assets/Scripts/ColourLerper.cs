﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourLerper : MonoBehaviour
{

    public float speed = 1.0f;
    public Color startColor;
    public Color endColor;
    public bool repeartable = false;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!repeartable)
        {
            float t = (Time.time - startTime) * speed;
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        }

        else
        {
            float t = (Mathf.Sin(Time.time - startTime) * speed);
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        }
    }
}
