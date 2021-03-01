using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoLoop : MonoBehaviour
{
    Vector3[] cubes = new Vector3[16];
    int index = 0;
    float a, b;

    void Start()
    {
        a = 0;
        b = 10;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomValue();
            print(cubes[index - 1]);
        }
    }

    void RandomValue()
    {
    Start:
        Vector3 val;
        while (true)
        {
            val = new Vector3(Random.Range(a, b), Random.Range(a, b), Random.Range(a, b));
            for (int i = 0; i < cubes.Length; i++)
            {
                if (val == cubes[i])
                {
                    goto Start;
                }   
            }
            goto Outer;
        }
    Outer:
        cubes[index++] = val;
    }
}
