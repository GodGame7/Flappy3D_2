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

    //ȭ���� �����̴� �ڷ�ƾ
    IEnumerator Blink_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);

            button.SetActive(!button.activeSelf);
        }
    }

    //��ġ �̺�Ʈ
    public void Start_button()
    {
        StartCoroutine(Start_Game());
    }

    //���� �����ϴ� �ڷ�ƾ
    IEnumerator Start_Game()
    {
        //���� ����� �߰� �̻� ������,
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("IntroScene") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f);

        //�����ϴ� �ִϸ��̼� ����
        animator.SetTrigger("Start");
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Standing") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        //�Ʒ��� �̵�
        float duration = 1.5f;
        float Timer = 0f;
        //������ġ
        Vector3 startPos = player_transform.position;
        //������ġ
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
