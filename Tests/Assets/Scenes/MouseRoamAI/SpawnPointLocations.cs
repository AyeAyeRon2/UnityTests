using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointLocations : MonoBehaviour
{
    public GameObject[] spawnPoints;
    [HideInInspector] public Vector3[] spawnPositions;

    private int numberOfSpawnPoints;

    void Start()
    {
        numberOfSpawnPoints = spawnPoints.Length;

        spawnPositions = new Vector3[numberOfSpawnPoints];

        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            spawnPositions[i] = spawnPoints[i].transform.position;
        }

        print(numberOfSpawnPoints);
    }
}
