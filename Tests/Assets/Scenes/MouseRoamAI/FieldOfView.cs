using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public MouseRoamNPC mouseRoamNPCScript;

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask playerMask;
    public LayerMask obstacleMask;
    [HideInInspector]
    public List<Transform> visiblePlayers = new List<Transform>();

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);

        mouseRoamNPCScript = GetComponent<MouseRoamNPC>();
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visiblePlayers.Clear();
        Collider[] playerInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for (int i = 0; i < playerInViewRadius.Length; i++)
        {
            Transform player = playerInViewRadius[i].transform;
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToPlayer) < viewAngle / 2)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);

                if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask))
                {
                    StopCoroutine(mouseRoamNPCScript.MouseMovement());
                    mouseRoamNPCScript.isRoaming = false;
                    mouseRoamNPCScript.isWalkingHome = false;
                    mouseRoamNPCScript.isRunningHome = true;
                    mouseRoamNPCScript.stopsTillHome = mouseRoamNPCScript.numberofStops;
                    visiblePlayers.Add(player);
                }
            }
        }
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
