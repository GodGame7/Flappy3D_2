using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLoop : MonoBehaviour
{ 
    private float groundLength;

    private void Awake()
    {
        groundLength = 10 * transform.Find("Plane").transform.localScale.z;
    }

    private void Update()
    {
        if (transform.position.z <= -groundLength * 0.6f)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector3 position = 2 * groundLength * Vector3.forward;
        transform.position += position;
    }
}
