using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireLocation : MonoBehaviour
{
    public GameObject[] wires;
    [HideInInspector] public Vector3[] wirePosition;

    private int numberOfWires;

    void Start()
    {
        numberOfWires = wires.Length;

        wirePosition = new Vector3[numberOfWires];

        for (int i = 0; i < numberOfWires; i++)
        {
            wirePosition[i] = wires[i].transform.position;
        }
    }
}
