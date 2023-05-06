using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject mushRoom;
    [SerializeField] private GameObject miniMush;
    [SerializeField] private GameObject star;
    private float LastSpawnItem = 0f;
    private int ranNum;
    private void Awake()
    {
        coin = GameObject.FindGameObjectWithTag("Coin");
        mushRoom = GameObject.FindGameObjectWithTag("Mush");
        miniMush = GameObject.FindGameObjectWithTag("MiniMush");
        star = GameObject.FindGameObjectWithTag("Star");
    }
    private void OnEnable()
    {

        ranNum = Random.Range(0, 7);
        switch (ranNum)
        {
            case 0:
                {
                    SetCoin();
                }
                break;
            case 1:
                {
                    SetCoin();
                }
                break;
            case 2:
                {
                    //노템 일부러 비워둠
                }
                break;
            case 3:
                {
                    //노템 일부러 비워둠
                }
                break;
            case 4:
                {
                    SetMush();
                }
                break;
            case 5:
                {
                    SetMiniMush();
                }
                break;
            case 6:
                {
                    SetStar();
                }
                break;

        }


    }


    public void SetCoin()
    {
        coin.SetActive(true);
        coin.transform.position = transform.position;
        LastSpawnItem = 0;
    }

    public void SetMush()
    {
        mushRoom.SetActive(true);
        mushRoom.transform.position = transform.position;
        LastSpawnItem = 0;
    }
    public void SetMiniMush()
    {
        miniMush.SetActive(true);
        miniMush.transform.position = transform.position;
        LastSpawnItem = 0;
    }

    public void SetStar()
    {
        star.SetActive(true);
        star.transform.position = transform.position;
        LastSpawnItem = 0;
    }
}
