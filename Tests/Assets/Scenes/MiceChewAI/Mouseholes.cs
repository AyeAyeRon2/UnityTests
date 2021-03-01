using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouseholes : MonoBehaviour
{
    public GameObject[] mouseholes;
    [HideInInspector] public Vector3[] holePosition;

    private int numberOfMouseholes;

    void Start()
    {
        numberOfMouseholes = mouseholes.Length;
        // not sure i need this ???
        //mouseholes = new GameObject[numberOfMouseholes];

        holePosition = new Vector3[numberOfMouseholes];

        for (int i = 0; i < numberOfMouseholes; i++)
        {
            holePosition[i] = mouseholes[i].transform.position;
        }
    }
}
