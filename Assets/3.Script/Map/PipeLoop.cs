using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLoop : MonoBehaviour
{
    private const float minPipeHeight = 0f;
    private const float maxPipeHeight = 4.5f;

    [SerializeField]
    private float setPosition = 20;
    [SerializeField]
    private float returnPosition = 10;
    [SerializeField]
    private int cnt = 3;

    private void OnEnable()
    {
        float height = Random.Range(minPipeHeight, maxPipeHeight);

        transform.position = new Vector3(0, height, transform.position.z);
    }

    private void Update()
    {
        if (transform.position.z <= -returnPosition)
        {
            Reposition(setPosition);
        }
    }

    private void Reposition(float length)
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        Vector3 position = length * cnt * Vector3.forward;
        transform.position += position;
    }
}
