using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    private ItemData itemData;
    public event System.Action OnItem;
    [Header("�÷��̾�")]
    [SerializeField] private GameObject player;
    [SerializeField] private Renderer playerRender;

    [Header("�����")]
    [SerializeField] private AudioClip mushRoomClip;
    [SerializeField] private AudioClip starClip;
    [SerializeField] private AudioSource Audio;
    WaitForSeconds colorTime = new WaitForSeconds(0.01f);
    private float endStarTime = 0f;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //�̺�Ʈ�߻�

            OnItem?.Invoke();
            gameObject.SetActive(false);
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
        // ���� ����� ����
        Audio.PlayOneShot(mushRoomClip);
        //ũ�� ����
        player.transform.localScale = itemData.scale;

        yield return new WaitForSeconds(itemData.itemTime);
        //ũ�� ����
        player.transform.localScale = new Vector3(1, 1, 1);
    }

    private IEnumerator Star_co()
    {
        //��Ÿ ����� ����
        Audio.PlayOneShot(starClip);
        //�ݶ��̴� ����

        // 5�ʰ� ���������� ������
        while (endStarTime <= 5f)
        {
            
            endStarTime += Time.deltaTime;
            playerRender.material.color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f);
            yield return colorTime;
        }
        //�ٽ� �������� ����
        playerRender.material.color = Color.white;
        //�ݶ��̴� ����
        
        endStarTime = 0;
    }
}
