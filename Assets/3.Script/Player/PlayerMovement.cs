using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpforce;
    public float speed;
    [SerializeField] private PlayerInput input;
    [SerializeField] private Rigidbody rb;


    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (input.input)
        {
            rb.AddForce(transform.up * jumpforce * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }
}
