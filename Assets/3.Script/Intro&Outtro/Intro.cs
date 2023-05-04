using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField]private float blinkInterval = 1f;
    [SerializeField]private GameObject button;
    [SerializeField] private Transform player_transform;
    Coroutine coroutine;

    private void Awake()
    {
        GameObject.Find("Player").TryGetComponent(out animator);
        GameObject.Find("Player").TryGetComponent(out player_transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutine == null)
            coroutine = StartCoroutine(Blink_co());
    }

    IEnumerator Blink_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);

            button.SetActive(!button.activeSelf);
        }
    }

    public void Start_button()
    {
        StartCoroutine(Start_Game());
    }

    IEnumerator Start_Game()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("IntroScene") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f);

        animator.SetTrigger("Start");
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Standing") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        SceneManager.LoadScene("Game");
    }
}
