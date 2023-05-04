using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemData",fileName ="ItemData")]
public class ItemData : ScriptableObject
{
    [Header("아이템 먹었는지")]
    public bool isGetItem;

    [Header("아이템 적용 시간")]
    public float itemTime = 5f;

    [Header("변수")]
    public Vector3 scale = new Vector3(1.5f, 1.5f, 1.5f); //크기 1.5배
    public float speed = 1f; // 속도밸런스는 추후변경    
    


}
