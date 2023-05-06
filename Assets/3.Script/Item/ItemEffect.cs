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
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip starClip;
    [SerializeField] private AudioClip desertClip;
    [SerializeField] private AudioClip minimushClip;
    [SerializeField] private AudioClip resetTransformClip;
    [SerializeField] private AudioSource Audio;
    [SerializeField] private AudioSource bgmAudio;
    [Header("�̺�Ʈ")]

    public UnityEvent OnItem;
    public UnityEvent<float> OnBooster;
    private ScrollObject Scroll;
    WaitForSeconds colorTime = new WaitForSeconds(0.01f);
    private float endStarTime = 0f;
    private void Awake()
    {
        //gameObject.SetActive(true) ;
        Scroll = FindObjectOfType<ScrollObject>();

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
        //���ھ� +1 
        GameManager.Instance.AddScore();
        Audio.PlayOneShot(coinClip);
        gameObject.SetActive(false);
        
    }
    public void OnMiniMush()
    {
        StartCoroutine(MiniMushroom_co());
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
        Audio.PlayOneShot(resetTransformClip);
        gameObject.SetActive(false);

    }

    private IEnumerator MiniMushroom_co()
    {
        gameObject.transform.position = new Vector3(999, 999, 999);
        // ���� ����� ����
        Audio.PlayOneShot(minimushClip);
        //ũ�� ����
        player.transform.localScale = itemData.miniscale;

        yield return new WaitForSeconds(itemData.itemTime);
        //ũ�� ����
        player.transform.localScale = new Vector3(1, 1, 1);
        Audio.PlayOneShot(resetTransformClip);
        gameObject.SetActive(false);

    }

    private IEnumerator Star_co()
    {
        //���⼭ �ӵ��÷��ְ�
        GameManager.Instance.isBooster = true;
        OnItem.Invoke();
        //��Ÿ ����� ����
        bgmAudio.PlayOneShot(starClip);
        gameObject.transform.position = new Vector3(999, 999, 999);
        GameManager.Instance.isBooster = true;

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
        
        
        //���⼭ �ӵ� �ٽø���
        GameManager.Instance.isBooster = false;
        bgmAudio.clip = desertClip;
        bgmAudio.Play();
        endStarTime = 0;
        gameObject.SetActive(false);
        yield return null;

    }
}
