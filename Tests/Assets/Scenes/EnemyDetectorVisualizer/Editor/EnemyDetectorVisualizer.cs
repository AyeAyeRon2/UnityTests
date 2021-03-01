using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyDetector))]
public class EnemyDetectorVisualizer : Editor
{
    private void OnSceneGUI()
    {
        // target refers to the game object the script is attached to
        EnemyDetector sensor = (EnemyDetector)target;

        Handles.color = Color.white;

        // range visualizer
        Handles.DrawWireArc(sensor.transform.position, Vector3.up, sensor.transform.forward, 360, sensor.sensorRange);

        // fov visualizer
        Vector3 right = (sensor.transform.forward * Mathf.Cos(sensor.sensorAngle * Mathf.Deg2Rad) + sensor.transform.right * Mathf.Sin(sensor.sensorAngle * Mathf.Deg2Rad)).normalized * sensor.sensorRange;
        Handles.DrawLine(sensor.transform.position, sensor.transform.position + right);
        Vector3 left = (sensor.transform.forward * Mathf.Cos(sensor.sensorAngle * Mathf.Deg2Rad) - sensor.transform.right * Mathf.Sin(sensor.sensorAngle * Mathf.Deg2Rad)).normalized * sensor.sensorRange;
        Handles.DrawLine(sensor.transform.position, sensor.transform.position + left);

        // draw red line between player and visible target
        Handles.color = Color.red;
        foreach (GameObject g in sensor.targetsInView)
        {
            Handles.DrawLine(sensor.transform.position, g.transform.position);
        }
    }
}

// TASK: draw the line, only when target is in ‘line of sight’ 
// i.e. when there are no obstacles between player and target
