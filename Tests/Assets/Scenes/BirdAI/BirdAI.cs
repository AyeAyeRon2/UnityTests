using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    public BirdSpawnLocations birdSpawnpointLocations;
    private Renderer ground;

    [SerializeField] private GameObject groundObject;

    private Vector3 homeLocation;
    private Vector3 nextDestination;

    public float distanceFromBoundary;
    private float xRange, yRange, zRange;
    private float birdSpeed;
    [HideInInspector] public int numberOfLocations = 0;
    public int locationsTillHome;

    [HideInInspector] public bool isFlying;
    [HideInInspector] public bool isFlyingHome;

    void Start()
    {
        groundObject = GameObject.Find("Ground");
        ground = groundObject.GetComponent<Renderer>();

        CreateRandomPosition();

        homeLocation = gameObject.transform.position;

        isFlying = true;
        isFlyingHome = false;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextDestination, birdSpeed);

        if (isFlying)
        {
            BirdMovement();

            if (Vector3.Distance(transform.position, nextDestination) < 0.001f)
            {
                CreateRandomPosition();
                numberOfLocations++;
            }
        }

        if (numberOfLocations == locationsTillHome)
        {
            BirdMovement();
            isFlying = false;
            isFlyingHome = true;
        }

        if (isFlyingHome)
        {
            nextDestination = homeLocation;
            BirdFliesHome();
        }

        print("Bird speed: " + birdSpeed);
    }

    private void CreateRandomPosition()
    {
        xRange = Random.Range(ground.bounds.min.x + distanceFromBoundary, ground.bounds.max.x - distanceFromBoundary);
        zRange = Random.Range(ground.bounds.min.z + distanceFromBoundary, ground.bounds.max.z - distanceFromBoundary);
        yRange = ground.transform.position.y + Random.Range(10f, 20f);

        Vector3 newNextDestination = new Vector3(xRange, yRange, zRange);
        nextDestination = newNextDestination;

        print("Next Location: " + nextDestination);
    }

    public void BirdMovement()
    {
        birdSpeed = 2f * Time.deltaTime;
    }

    private void BirdFliesHome()
    {
        if (numberOfLocations == locationsTillHome && Vector3.Distance(gameObject.transform.position, homeLocation) < 1f)
        {
            Destroy(gameObject);
        }
    }
}