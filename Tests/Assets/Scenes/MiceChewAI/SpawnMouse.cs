using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMouse : MonoBehaviour
{
    public WireLocation wiresScript;
    public Mouseholes mouseholesScript;
    
    public GameObject mousePrefab;

    private int randomNumber;
    private Transform randomSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChooseSpawnPoint();
            InstantiateMouse();
        }
    }

    public void ChooseSpawnPoint()
    {
        randomNumber = Random.Range(0, mouseholesScript.holePosition.Length);
        randomSpawn = mouseholesScript.mouseholes[randomNumber].transform;
    }

    public void InstantiateMouse()
    {
        Instantiate(mousePrefab, randomSpawn);
    }
}
