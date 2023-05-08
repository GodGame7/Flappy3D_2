using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    private GameObject coin;
    private GameObject mushRoom;
    private GameObject miniMush;
    private GameObject star;
    private float LastSpawnItem = 0f;
    private int ranNum;
    [SerializeField] GameObject[] CoinItem = new GameObject[3];
    [SerializeField] GameObject[] mushRoomItem = new GameObject[3];
    [SerializeField] GameObject[] miniMushItem = new GameObject[3];
    [SerializeField] GameObject[] starItem = new GameObject[3];
    private int coinItemNum = 0;
    private int mushRoomItemNum = 0;
    private int miniMushItemNum = 0;
    private int starItemNum = 0;
    private Vector3 CreateItemPosition = new Vector3(999, 999, 999);

    private void Awake()
    {
        coin = GameObject.FindGameObjectWithTag("Coin");
        mushRoom = GameObject.FindGameObjectWithTag("Mush");
        miniMush = GameObject.FindGameObjectWithTag("MiniMush");
        star = GameObject.FindGameObjectWithTag("Star");
        for (int i=0; i<3; i++)
        {
            CoinItem[i] = Instantiate(coin, CreateItemPosition, Quaternion.Euler(-90,0,0));
            CoinItem[i].SetActive(false);
            mushRoomItem[i] = Instantiate(mushRoom, CreateItemPosition, Quaternion.Euler(270, 180, 0));
            mushRoomItem[i].SetActive(false);
            miniMushItem[i] = Instantiate(miniMush, CreateItemPosition, Quaternion.Euler(-90, 0, 180));
            miniMushItem[i].SetActive(false);
            starItem[i] = Instantiate(star, CreateItemPosition, Quaternion.Euler(0, 180, 0));
            starItem[i].SetActive(false);
        }
        RandomSpawn();
    }

    public void RandomSpawn()
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
        coinItemNum++;
        int index = coinItemNum % 3;
        CoinItem[index].SetActive(true);
        CoinItem[index].transform.position = transform.position;
        LastSpawnItem = 0;
    }

    public void SetMush()
    {
        mushRoomItemNum++;
        int index = mushRoomItemNum % 3;
        mushRoomItem[index].SetActive(true);
        mushRoomItem[index].transform.position = transform.position;
        LastSpawnItem = 0;
    }
    public void SetMiniMush()
    {
        miniMushItemNum++;
        int index = miniMushItemNum % 3;
        miniMushItem[index].SetActive(true);
        miniMushItem[index].transform.position = transform.position;
        LastSpawnItem = 0;
    }

    public void SetStar()
    {
        starItemNum++;
        int index = starItemNum % 3;
        starItem[index].SetActive(true);
        starItem[index].transform.position = transform.position;
        LastSpawnItem = 0;
    }
}
