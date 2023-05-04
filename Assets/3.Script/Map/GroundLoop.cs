using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    private float groundLength;

    private void Awake()
    {
        groundLength = 10 * transform.Find("Plane").transform.localScale.z;
        //if (gameObject.CompareTag("Original"))
        //{
        //    GameObject clone = Instantiate(gameObject);
        //    clone.name = gameObject.name + "2";
        //    clone.transform.position += groundLength * Vector3.forward;
        //    clone.tag = "Untagged";
        //}
    }

    private void Update()
    {
        if (transform.position.z <= -groundLength * 0.5f)
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
