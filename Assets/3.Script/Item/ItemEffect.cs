using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemEffect : MonoBehaviour
{


    [SerializeField] private ItemData itemData;
    [Header("�÷��̾�")]
    [SerializeField] private GameObject player;
    [SerializeField] private Renderer[] playerRender;

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

    
    [System.Serializable]
    public class BoosterEvent : UnityEvent<float> { }
    BoosterEvent OnStarBooster;
    private ScrollObject[] Scroll;
    //WaitForSeconds colorTime = new WaitForSeconds(0.01f);
    private float endStarTime = 0f;
    private void OnEnable()
    {
        //Scroll = FindObjectsOfType<ScrollObject>();
        playerRender = player.GetComponentsInChildren<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        OnStarBooster = new BoosterEvent();
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
        //��Ÿ�� �Ծ��� ����, ��ũ�ѿ�����Ʈ�� ã����
        Scroll = FindObjectsOfType<ScrollObject>();
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
        //��� ��ũ�� �ӵ� �ø�
        for (int i = 0; i < Scroll.Length; i++)
        {
            OnStarBooster.RemoveListener(Scroll[i].BoosterOff);
        }
        for (int i = 0; i < Scroll.Length; i++)
        {
            OnStarBooster.AddListener(Scroll[i].BoosterOn);
        }

        //OnStarBooster.RemoveListener(Scroll.BoosterOff);
        //OnStarBooster.AddListener(Scroll.BoosterOn);
        OnStarBooster?.Invoke(itemData.speed);
        // �ν���
        bgmAudio.Stop();
        
        //��Ÿ ����� ����
        bgmAudio.PlayOneShot(starClip);
        gameObject.transform.position = new Vector3(999, 999, 999);
        GameManager.Instance.isBooster = true;

        for (int i =0; i<playerRender.Length; i++)
        {
            playerRender[i].material.color = Color.yellow;
        }
        
        yield return new WaitForSeconds(7f);
        //�ٽ� �������� ����
        for (int i = 0; i < playerRender.Length; i++)
        {
            playerRender[i].material.color = Color.white;
        }


        //���⼭ �ӵ� �ٽø���
        //���Ⱑ �ȵ� (�ν��� ��ž)

        //��� ��ũ�� �ӵ� ����
        for (int i = 0; i < Scroll.Length; i++)
        {
            OnStarBooster.RemoveListener(Scroll[i].BoosterOn);
        }
        for (int i = 0; i < Scroll.Length; i++)
        {
            OnStarBooster.AddListener(Scroll[i].BoosterOff);
        }
        //OnStarBooster.RemoveListener(Scroll.BoosterOn);
        //OnStarBooster.AddListener(Scroll.BoosterOff);

        OnStarBooster?.Invoke(itemData.speed);
        //�ν���

        bgmAudio.Stop();
        GameManager.Instance.isBooster = false;
        bgmAudio.clip = desertClip;
        bgmAudio.Play();
        endStarTime = 0;
        gameObject.SetActive(false);
        yield return null;

    }
}
