using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemEffect : MonoBehaviour
{


    [SerializeField] private ItemData itemData;
    [Header("플레이어")]
    [SerializeField] private GameObject player;
    [SerializeField] private Renderer[] playerRender;

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
            //이벤트발생
            OnItem?.Invoke();
        }
    }
    public void OnStar()
    {
        //스타를 먹었을 때만, 스크롤오브젝트를 찾도록
        Scroll = FindObjectsOfType<ScrollObject>();
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
        //모든 스크롤 속도 올림
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
        // 부스터
        bgmAudio.Stop();
        
        //스타 오디오 실행
        bgmAudio.PlayOneShot(starClip);
        gameObject.transform.position = new Vector3(999, 999, 999);
        GameManager.Instance.isBooster = true;

        for (int i =0; i<playerRender.Length; i++)
        {
            playerRender[i].material.color = Color.yellow;
        }
        
        yield return new WaitForSeconds(7f);
        //다시 원색으로 복귀
        for (int i = 0; i < playerRender.Length; i++)
        {
            playerRender[i].material.color = Color.white;
        }


        //여기서 속도 다시리셋
        //여기가 안됨 (부스터 스탑)

        //모든 스크롤 속도 내림
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
        //부스터

        bgmAudio.Stop();
        GameManager.Instance.isBooster = false;
        bgmAudio.clip = desertClip;
        bgmAudio.Play();
        endStarTime = 0;
        gameObject.SetActive(false);
        yield return null;

    }
}
