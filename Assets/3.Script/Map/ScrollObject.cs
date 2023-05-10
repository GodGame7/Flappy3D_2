using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ScrollObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 Direction = Vector3.back;

    private void Update()
    {        
        if (GameManager.Instance.isStart)
        {
            transform.Translate(GameManager.Instance.speed * Time.deltaTime * Direction);
        }
    }

    public void BoosterOn(float boosterSpeed)
    {
        GameManager.Instance.speed *= boosterSpeed;
    }
    public void BoosterOff(float boosterSpeed)
    {
        GameManager.Instance.speed /= boosterSpeed;
    }
}
