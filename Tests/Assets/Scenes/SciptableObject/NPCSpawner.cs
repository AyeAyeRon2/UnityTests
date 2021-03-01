using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject warriorPrefab;
    private GameObject[] warriorCount;

    public int numberOfWarriors;
    public float range;

    Vector3 randomPosition;

    void Awake()
    {
        float x, y, z;

        x = Random.Range(-range, range);
        z = Random.Range(-range, range);

        randomPosition = new Vector3(x, gameObject.transform.position.y, z);

        warriorCount = new GameObject[numberOfWarriors];

        for (int i = 0; i < warriorCount.Length; i++)
        {
            GameObject clone = (GameObject) Instantiate(warriorPrefab, randomPosition, gameObject.transform.rotation);

            warriorCount[i] = clone;

            warriorCount[i].name = "Warrior " + i;
        }
    }

    void Update()
    {
        
    }
}
