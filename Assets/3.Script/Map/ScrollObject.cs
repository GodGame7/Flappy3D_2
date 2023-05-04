using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{ 
    [SerializeField]
    private float speed = 10f;

    private void Update()
    {
        if (GameManager.Instance.isStart)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.back);
        }
    }
}
