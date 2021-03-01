using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatePrefabs : MonoBehaviour
{

    public GameObject objectPrefab;

    void Start()
    {
        objectPrefab = Instantiate(objectPrefab, transform.position, transform.rotation);
        objectPrefab.name = "Collectible";
    }
    
    void Update()
    {
        GameObject.Find("Collectible").transform.Translate(Vector3.up * Time.deltaTime);
    }
}
