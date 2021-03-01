using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopScript : MonoBehaviour
{
    private int panels;

    public GameObject ground;
    private float distance;

    void Start()
    {
        panels = LayerMask.GetMask("Panels");
    }
    
    void FixedUpdate()
    {
        distance = transform.position.y - ground.transform.position.y;

        bool hit = Physics.Raycast(transform.position, -transform.position, distance, panels);

        Debug.DrawRay(transform.position, -distance * transform.up, Color.black);

        if (hit)
        {
            Debug.Log("WOAH");
        }
    }
}
