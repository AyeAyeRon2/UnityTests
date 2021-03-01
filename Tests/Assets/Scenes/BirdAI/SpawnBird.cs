using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour
{
    public BirdSpawnLocations birdSpawnpointLocations;

    public GameObject birdPrefab;

    private int randomNumber;
    private Vector3 randomSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChooseSpawnPoint();
            InstantiateBird();
        }
    }

    public void ChooseSpawnPoint()
    {
        randomNumber = Random.Range(0, birdSpawnpointLocations.spawnPoints.Length);
        randomSpawn = birdSpawnpointLocations.spawnPoints[randomNumber].transform.position;
    }

    public void InstantiateBird()
    {
        Instantiate(birdPrefab, randomSpawn, transform.rotation);
    }
}
