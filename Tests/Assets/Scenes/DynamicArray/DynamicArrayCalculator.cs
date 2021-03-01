using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicArrayCalculator : MonoBehaviour
{
    public Renderer plane;
    public GameObject myPrefab;

    public List<GameObject> instantiatedPrefabs;

    public float boundaryLimit;

    void Start()
    {
        instantiatedPrefabs = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCube();
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    instantiatedPrefabs.RemoveAt(0);
        //    Destroy(instantiatedPrefabs[0]);
        //}

        Debug.Log(instantiatedPrefabs.Count);
    }

    private void SpawnCube()
    {
        float xPosition = Random.Range(plane.bounds.min.x + boundaryLimit, plane.bounds.max.x - boundaryLimit);
        float zPosition = Random.Range(plane.bounds.min.z + boundaryLimit, plane.bounds.max.z - boundaryLimit);
        float yPosition = Random.Range(1f, 5f);

        Vector3 randomPosiiton = new Vector3(xPosition, yPosition, zPosition);

        instantiatedPrefabs.Add(Instantiate(myPrefab, randomPosiiton, Quaternion.identity));
    }
}
