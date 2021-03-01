using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [Range(0, 20)]
    public float sensorRange = 5.0f;

    [Range(0, 180)]
    public float sensorAngle = 45.0f;

    [HideInInspector]
    public List<GameObject> targetsInView = new List<GameObject>();

    public LayerMask targetLayer;

    private void FixedUpdate()
    {
        FindTargetsInView();
    }

    private void FindTargetsInView()
    {
        targetsInView.Clear();

        Collider[] targetsInRange = Physics.OverlapSphere(transform.position, sensorRange, targetLayer);

        foreach (Collider collider in targetsInRange)
        {
            if (Vector3.Angle(transform.forward, (collider.transform.position - transform.position).normalized) < sensorAngle)
            {
                targetsInView.Add(collider.gameObject);
            }
        }
    }
}
