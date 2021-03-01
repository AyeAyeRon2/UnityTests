using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 1.0f;
    public bool clicked = false;
    public bool rotating = false;
    Vector3 end;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && rotating == false)
        {
            end = transform.right;
            rotating = true;
            clicked = true;
        }

        if (clicked)
        {
            Rotate90();
        }
    }

    private void Rotate90()
    {
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, end,
            speed * Time.deltaTime, 0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

        if (transform.forward == end)
        {
            rotating = false;
            clicked = false;
        }
    }
}
