using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MouseChewNPC : MonoBehaviour
{
    private WireLocation wiresScript;

    NavMeshAgent navMeshAgent;

    public GameObject wireLocation;

    [HideInInspector] public Vector3 nextDestination;

    //private bool mouseActive;

    void Start()
    {
        wiresScript = wireLocation.GetComponent<WireLocation>();

        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        //mouseActive = false;
    }

    void Update()
    {
        //if (mouseActive != false)
        //{
            navMeshAgent.SetDestination(nextDestination);
        //}
    }
}