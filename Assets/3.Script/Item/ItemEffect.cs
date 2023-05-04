using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemEffect : MonoBehaviour
{


    [SerializeField] private ItemData itemData;
    [Header("�÷��̾�")]
    [SerializeField] private GameObject player;
    [SerializeField] private Renderer playerRender;

    [Header("�����")]
    [SerializeField] private AudioClip mushRoomClip;
    [SerializeField] private AudioClip starClip;
    [SerializeField] private AudioClip desertClip;
    [SerializeField] private AudioSource Audio;
    [SerializeField] private AudioSource bgmAudio;
    [Header("�̺�Ʈ")]
    public UnityEvent OnItem;
    WaitForSeconds colorTime = new WaitForSeconds(0.01f);
    private float endStarTime = 0f;
    private void Awake()
    {
        //gameObject.SetActive(true) ;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //�̺�Ʈ�߻�

            OnItem?.Invoke();
        }
    }
    public void OnStar()
    {
        StartCoroutine(Star_co());
    }

    public void OnMushroom()
    {
        StartCoroutine(Mushroom_co());
    }

    public void OnCoin()
    {
        //���ھ� +100 
    }

    private IEnumerator Mushroom_co()
    {
        gameObject.transform.position = new Vector3(999, 999, 999);
        // ���� ����� ����
        Audio.PlayOneShot(mushRoomClip);
        //ũ�� ����
        player.transform.localScale = itemData.scale;

        yield return new WaitForSeconds(itemData.itemTime);
        //ũ�� ����
        player.transform.localScale = new Vector3(1, 1, 1);
        gameObject.SetActive(false);

    }

    private IEnumerator Star_co()
    {
        //��Ÿ ����� ����
        bgmAudio.PlayOneShot(starClip);
        gameObject.transform.position = new Vector3(999, 999, 999);
        //�ݶ��̴� ����

        // 5�ʰ� ���������� ������
        while (endStarTime <= 5f)
        {

            endStarTime += Time.deltaTime;
            //playerRender.material.color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f);
            yield return colorTime;
        }
        //�ٽ� �������� ����
        //playerRender.material.color = Color.white;
        //�ݶ��̴� ����
        bgmAudio.clip = desertClip;
        bgmAudio.Play();
        endStarTime = 0;
        gameObject.SetActive(false);
        yield return null;

    }
}
