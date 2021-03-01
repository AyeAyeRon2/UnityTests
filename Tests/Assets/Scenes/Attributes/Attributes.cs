using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    [Header ("This is a header")]
    [Tooltip ("Slide the number in intervals of 1")]
    [Range(0, 10)]
    public int x;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
