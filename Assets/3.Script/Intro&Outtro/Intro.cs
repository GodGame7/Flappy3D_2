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
    [SerializeField] private AudioSource player_audio;
    Coroutine coroutine;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out animator);
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player_transform);
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player_audio);
    }

    void Update()
    {
        if (coroutine == null)
            coroutine = StartCoroutine(Blink_co());
    }

    //화면이 깜빡이는 코루틴
    IEnumerator Blink_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);

            button.SetActive(!button.activeSelf);
        }
    }

    //터치 이벤트
    public void Start_button()
    {
        StartCoroutine(Start_Game());
    }

    //게임 시작하는 코루틴
    IEnumerator Start_Game()
    {
        //점프 모션이 중간 이상 끝나면,
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("IntroScene") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f);

        //시작하는 애니메이션 시작
        animator.SetTrigger("Start");
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Standing") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        //아래로 이동
        float duration = 1.5f;
        float Timer = 0f;
        //시작위치
        Vector3 startPos = player_transform.position;
        //종료위치
        Vector3 endPos = new Vector3(startPos.x, -3f, startPos.z);

        player_audio.Play();
        while (Timer < duration)
        {
            player_transform.position = Vector3.Lerp(startPos, endPos, (Timer / duration));
            Timer += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("Game");
    }
}
