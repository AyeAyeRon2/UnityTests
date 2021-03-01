using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptA : MonoBehaviour
{
    public Vector3 vector3;

    //public bool newPosition;

    void Start()
    {
        vector3 = gameObject.transform.position;
        //newPosition = false;   
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewPosition();
            //newPosition = true;
        }

        //if (newPosition == true)
        //{
        //    print(vector3);
        //}
    }

    public void NewPosition()
    {
        print(vector3);
    }
}
