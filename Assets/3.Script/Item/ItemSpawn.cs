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
    GameObject[] CoinItem = new GameObject[3];
    GameObject[] mushRoomItem = new GameObject[3];
    GameObject[] miniMushItem = new GameObject[3];
    GameObject[] starItem = new GameObject[3];
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
            CoinItem[i] = Instantiate(coin, CreateItemPosition, Quaternion.identity);
            CoinItem[i].SetActive(false);
            mushRoomItem[i] = Instantiate(mushRoom, CreateItemPosition, Quaternion.identity);
            mushRoomItem[i].SetActive(false);
            miniMushItem[i] = Instantiate(miniMush, CreateItemPosition, Quaternion.identity);
            miniMushItem[i].SetActive(false);
            starItem[i] = Instantiate(star, CreateItemPosition, Quaternion.identity);
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
                    //���� �Ϻη� �����
                }
                break;
            case 3:
                {
                    //���� �Ϻη� �����
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
        CoinItem[coinItemNum].SetActive(true);
        coin.transform.position = transform.position;
        LastSpawnItem = 0;
        if (coinItemNum >= 3)
        { 
            coinItemNum = 0; 
        }
        Debug.Log("����"+coinItemNum);
    }

    public void SetMush()
    {
        mushRoomItemNum++;
        mushRoomItem[mushRoomItemNum].SetActive(true);
        mushRoom.transform.position = transform.position;
        LastSpawnItem = 0;
        if (mushRoomItemNum >= 3)
        {
            mushRoomItemNum = 0;
        }
        Debug.Log("���� ������ "+mushRoomItemNum);
    }
    public void SetMiniMush()
    {
        miniMushItemNum++;
        miniMushItem[miniMushItemNum].SetActive(true);
        miniMush.transform.position = transform.position;
        LastSpawnItem = 0;
        if (miniMushItemNum >= 3)
        {
            miniMushItemNum = 0;
        }
        Debug.Log("��������" +miniMushItemNum);
    }

    public void SetStar()
    {
        starItemNum++;
        starItem[starItemNum].SetActive(true);
        star.transform.position = transform.position;
        LastSpawnItem = 0;
        if (starItemNum >= 3)
        {
            starItemNum = 0;
        }
        Debug.Log("��" +starItemNum);
    }
}
