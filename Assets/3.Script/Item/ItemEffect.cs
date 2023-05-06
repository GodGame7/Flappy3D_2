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
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip starClip;
    [SerializeField] private AudioClip desertClip;
    [SerializeField] private AudioClip minimushClip;
    [SerializeField] private AudioClip resetTransformClip;
    [SerializeField] private AudioSource Audio;
    [SerializeField] private AudioSource bgmAudio;
    [Header("이벤트")]

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
        //스코어 +1 
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
        // 버섯 오디오 실행
        Audio.PlayOneShot(mushRoomClip);
        //크기 증가
        player.transform.localScale = itemData.scale;

        yield return new WaitForSeconds(itemData.itemTime);
        //크기 감소
        player.transform.localScale = new Vector3(1, 1, 1);
        Audio.PlayOneShot(resetTransformClip);
        gameObject.SetActive(false);

    }

    private IEnumerator MiniMushroom_co()
    {
        gameObject.transform.position = new Vector3(999, 999, 999);
        // 버섯 오디오 실행
        Audio.PlayOneShot(minimushClip);
        //크기 증가
        player.transform.localScale = itemData.miniscale;

        yield return new WaitForSeconds(itemData.itemTime);
        //크기 감소
        player.transform.localScale = new Vector3(1, 1, 1);
        Audio.PlayOneShot(resetTransformClip);
        gameObject.SetActive(false);

    }

    private IEnumerator Star_co()
    {
        //여기서 속도올려주고
        GameManager.Instance.isBooster = true;
        OnItem.Invoke();
        //스타 오디오 실행
        bgmAudio.PlayOneShot(starClip);
        gameObject.transform.position = new Vector3(999, 999, 999);
        GameManager.Instance.isBooster = true;

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
        
        
        //여기서 속도 다시리셋
        GameManager.Instance.isBooster = false;
        bgmAudio.clip = desertClip;
        bgmAudio.Play();
        endStarTime = 0;
        gameObject.SetActive(false);
        yield return null;

    }
}
