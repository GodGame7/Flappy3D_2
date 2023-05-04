using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpforce;
    public float startjumpforce;
    [SerializeField] private PlayerInput input;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator anim;

    private void Start()
    {
        input.OnClick += () => Jump();
        rb.useGravity = false;
    }
    public void Jump()
    {
        rb.velocity = Vector3.zero;
        anim.SetTrigger("Jump");
        rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
    }
    public void StartJump()
    {
        StartCoroutine("StartJump_co");
    }
    public IEnumerator StartJump_co()
    { 
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        rb.useGravity = true;
        rb.AddForce(transform.up * startjumpforce, ForceMode.Impulse);
    }
}
