using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    [SerializeField]
    private float setPosition = 100;
    [SerializeField]
    private float returnPosition = 50;

    private void Update()
    {
        if (transform.position.z <= -returnPosition)
        {
            Reposition(setPosition);
        }
    }

    private void Reposition(float length)
    {
        Vector3 position = length * Vector3.forward;
        transform.position += position;
    }
}
