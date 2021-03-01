using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseRoamNPC : MonoBehaviour
{
    public SpawnPointLocations spawnPointLocations;
    private Renderer ground;
    private NavMeshAgent navMeshAgent;

    [SerializeField] private GameObject groundObject;

    private Vector3 homeLocation;
    private Vector3 nextDestination;

    public float distanceFromBoundary;
    public int minWaitTime, maxWaitTime;
    private int waitTime;
    private float xRange, yRange, zRange;
    private float mouseSpeed;
    [HideInInspector] public int numberofStops = 0;
    public int stopsTillHome;

    [HideInInspector] public bool isRoaming;
    [HideInInspector] public bool isWalkingHome;
    [HideInInspector] public bool isRunningHome;

    void Start()
    {
        groundObject = GameObject.Find("Ground");
        ground = groundObject.GetComponent<Renderer>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        CreateRandomPosition();

        homeLocation = gameObject.transform.position;

        isRoaming = true;
        isWalkingHome = false;
        isRunningHome = false;
    }
    
    void Update()
    {
        navMeshAgent.SetDestination(nextDestination);

        if (isRoaming)
        {
            StartCoroutine(MouseMovement());
        }

        if (numberofStops == stopsTillHome)
        {
            StopCoroutine(MouseMovement());
            isRoaming = false;
            isWalkingHome = true;
        }

        if (isWalkingHome)
        {
            nextDestination = homeLocation;
            MouseGoesHome();
        }

        if (isRunningHome)
        {
            mouseSpeed = 10f;
            nextDestination = homeLocation;
            MouseGoesHome();
        }

        print("Mouse speed: " + mouseSpeed);
        //print("isRoaming: " + isRoaming);
        //print("isWalkingHome: " + isWalkingHome);
    }

    private void CreateRandomPosition()
    {
        xRange = Random.Range(ground.bounds.min.x + distanceFromBoundary, ground.bounds.max.x - distanceFromBoundary);
        zRange = Random.Range(ground.bounds.min.z + distanceFromBoundary, ground.bounds.max.z - distanceFromBoundary);
        
        Vector3 newNextDestination = new Vector3(xRange, 1, zRange);
        nextDestination = newNextDestination;

        print("Next Location: " + nextDestination);
    }

    private void CreateRandomWaitTime()
    {
        int newWaitTime = Random.Range(minWaitTime, maxWaitTime);
        waitTime = newWaitTime;
    }

    public IEnumerator MouseMovement()
    {
        mouseSpeed = 2f;
        navMeshAgent.speed = mouseSpeed;
        isRoaming = false;

        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    CreateRandomPosition();
                    CreateRandomWaitTime();

                    numberofStops++;
                    //print("Number of stops: " + numberofStops);
                }
            }
        }

        yield return new WaitForSeconds(waitTime);

        isRoaming = true;
    }

    private void MouseGoesHome()
    {
        if (numberofStops == stopsTillHome && Vector3.Distance(gameObject.transform.position, homeLocation) < 1f)
        {
            Destroy(gameObject);
        }
    }
}