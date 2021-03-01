using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCollectible : MonoBehaviour
{
    Animator chestLidAnimator;

    public GameObject collectablePrefab;

    private bool presentCollectable;
    private bool chestAvailable;

    Vector3 endPosition;

    void Start()
    {
        chestLidAnimator = GameObject.Find("ChestObject/Chest/ChestLid").GetComponent<Animator>();

        endPosition = new Vector3(gameObject.transform.position.x,
        gameObject.transform.position.y + 2f, gameObject.transform.position.y);

        presentCollectable = false;
        chestAvailable = true;
    }

    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, endPosition);

        gameObject.transform.Rotate(0, 0.1f, 0);

        if (chestAvailable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                chestLidAnimator.SetBool("OpenLid", true);

                collectablePrefab = Instantiate(collectablePrefab, gameObject.transform.position, gameObject.transform.rotation);
                collectablePrefab.name = "Collectable";

                presentCollectable = true;
                chestAvailable = false;
            }
        }

        GameObject.Find("Collectable").transform.rotation = gameObject.transform.rotation;
        GameObject.Find("Collectable").transform.position = gameObject.transform.position;

        if (presentCollectable)
        {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime);   
        }

        if (distance > 0 && distance < 0.5)
        {
            presentCollectable = false;
            Destroy(GameObject.Find("Collectable"), 10f);
        }
    }
}