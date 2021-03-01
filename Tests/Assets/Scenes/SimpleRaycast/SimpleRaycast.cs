using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRaycast : MonoBehaviour
{
    private float length = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool rayIntersectsSomething = Physics.Raycast(transform.position, -transform.position ,length);

        Debug.DrawRay(transform.position, -length*transform.up, Color.black);

        if (rayIntersectsSomething)
        {
            Destroy(GetComponent<Rigidbody>());
        }
    }
}
