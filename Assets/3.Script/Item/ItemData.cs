using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemData",fileName ="ItemData")]
public class ItemData : ScriptableObject
{
    [Header("������ �Ծ�����")]
    public bool isGetItem;

    [Header("������ ���� �ð�")]
    public float itemTime = 5f;

    [Header("����")]
    public Vector3 scale = new Vector3(1.5f, 1.5f, 1.5f); //ũ�� 1.5��
    public float speed = 1f; // �ӵ��뷱���� ���ĺ���    
    


}
