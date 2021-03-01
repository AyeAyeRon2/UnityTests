using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWire : MonoBehaviour
{
    public WireLocation wiresScript;
    public MouseChewNPC mouseNPCScript;

    private int randomNumber;
    [HideInInspector] public Vector3 randomWire;

    void Start()
    {
        ChooseRandomWire();
    }

    public void ChooseRandomWire()
    {
        randomNumber = Random.Range(0, wiresScript.wires.Length);
        randomWire = wiresScript.wirePosition[randomNumber];

        mouseNPCScript.nextDestination.Set(randomWire.x, randomWire.y, randomWire.z);

        print(mouseNPCScript.nextDestination);
    }
}
