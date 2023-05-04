using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField] private ItemEffect star;
    [SerializeField] private ItemEffect Coin;
    [SerializeField] private ItemEffect mushRoom;

    private void Awake()
    {
        star.OnItem += star.OnStar;
        Coin.OnItem += Coin.OnCoin;
        mushRoom.OnItem += mushRoom.OnMushroom;

    }
}
