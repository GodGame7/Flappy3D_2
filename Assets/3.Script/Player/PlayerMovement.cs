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
    //-------------¾À ¹ÌÀÛ¾÷
    public AudioClip clip_startjump;
    public AudioClip[] clips_jump;
    private AudioSource audios;
    //------------------------

    private void Awake()
    {
        audios = GetComponent<AudioSource>();
    }
    private void Start()
    {
        input.OnClick += () => Jump();
        rb.useGravity = false;
    }
    private int i = 0;
    private int index;
    public void Jump()
    {
        index = i % clips_jump.Length;
        i++;
        rb.velocity = Vector3.zero;
        anim.SetTrigger("Jump");
        audios.PlayOneShot(clips_jump[index]);
        rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
    }
    public void StartJump()
    {
        StartCoroutine("StartJump_co");
    }
    public IEnumerator StartJump_co()
    { 
        anim.SetTrigger("Start");
        audios.PlayOneShot(clip_startjump);
        yield return new WaitForSeconds(0.5f);
        rb.useGravity = true;
        rb.AddForce(transform.up * startjumpforce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
