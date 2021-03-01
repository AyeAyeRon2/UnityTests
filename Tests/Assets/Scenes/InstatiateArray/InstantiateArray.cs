using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateArray : MonoBehaviour
{
    public GameObject itemPrefab;

    private GameObject[] item;

    private Transform[] itemSpawners;

    private int numberOfChildren;
    private float scaleSize;
    private float scaleMulitplier;

    void Start()
    {
        numberOfChildren = gameObject.transform.childCount;
        Debug.Log(numberOfChildren);

        itemSpawners = new Transform[numberOfChildren];
        item = new GameObject[numberOfChildren];

        for (int i = 0; i < numberOfChildren; i++)
        {
            itemSpawners[i] = gameObject.transform.GetChild(i);

            Debug.Log(itemSpawners[i]);

            item[i] = Instantiate(itemPrefab, itemSpawners[i].transform.position, itemSpawners[i].transform.rotation);

            item[i].GetComponent<Rigidbody>().useGravity = false;
            item[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            Debug.Log(item[i]);

            scaleSize = 0f;
            scaleMulitplier = Random.Range(0f, 3f);

            item[i].transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
        }
    }

    void Update()
    {
        if (scaleSize < 5f)
        {
            scaleSize += scaleMulitplier * Time.deltaTime;

            Debug.Log(scaleSize);

            for (int i = 0; i < numberOfChildren; i++)
            {
                item[i].transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
            }
        }

        else if (scaleSize > 5f)
        {
            for (int i = 0; i < numberOfChildren; i++)
            {
                item[i].GetComponent<Rigidbody>().useGravity = true;
                item[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }

            for (int i = 0; i < numberOfChildren; i++)
            {
                if (Vector3.Distance(gameObject.transform.position, item[i].transform.position) > 30f)
                {
                    Destroy(item[i]);
                }
            }
        }
    }
}
