using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemEffect : MonoBehaviour
{


    [SerializeField] private ItemData itemData;
    [Header("플레이어")]
    [SerializeField] private GameObject player;
    [SerializeField] private Renderer playerRender;

    [Header("오디오")]
    [SerializeField] private AudioClip mushRoomClip;
    [SerializeField] private AudioClip starClip;
    [SerializeField] private AudioClip desertClip;
    [SerializeField] private AudioSource Audio;
    [SerializeField] private AudioSource bgmAudio;
    [Header("이벤트")]
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
            //이벤트발생

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
        //스코어 +100 
    }

    private IEnumerator Mushroom_co()
    {
        gameObject.transform.position = new Vector3(999, 999, 999);
        // 버섯 오디오 실행
        Audio.PlayOneShot(mushRoomClip);
        //크기 증가
        player.transform.localScale = itemData.scale;

        yield return new WaitForSeconds(itemData.itemTime);
        //크기 감소
        player.transform.localScale = new Vector3(1, 1, 1);
        gameObject.SetActive(false);

    }

    private IEnumerator Star_co()
    {
        //스타 오디오 실행
        bgmAudio.PlayOneShot(starClip);
        gameObject.transform.position = new Vector3(999, 999, 999);
        //콜라이더 제거

        // 5초간 랜덤색으로 깜빡임
        while (endStarTime <= 5f)
        {

            endStarTime += Time.deltaTime;
            //playerRender.material.color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f);
            yield return colorTime;
        }
        //다시 원색으로 복귀
        //playerRender.material.color = Color.white;
        //콜라이더 복귀
        bgmAudio.clip = desertClip;
        bgmAudio.Play();
        endStarTime = 0;
        gameObject.SetActive(false);
        yield return null;

    }
}
