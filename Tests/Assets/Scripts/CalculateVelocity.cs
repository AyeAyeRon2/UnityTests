using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateVelocity : MonoBehaviour
{
    public Vector3 prevPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = (transform.position - prevPosition) / Time.deltaTime;
        prevPosition = transform.position;

        Debug.Log(velocity);
    }
}
