using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public bool input = false;
    public event Action OnClick;
    private PlayerMovement move;
    private GameManager gm;

    private void Awake()
    {
        gm = GameManager.Instance;
        move = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
       MouseClick(); //Ver3
    }


    // Ver1. ����� ��ġ
    public void SingleTouch()
    {
     if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch Began");

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch End");
            }
        }
    }


    // Ver2 : Update���� ������ ��ǲ �� ��� ����, �̺�Ʈ�� ���� �� 1�� ���� ���.
    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gm.isStart) { OnClick(); }
            else if (!gm.isStart && !gm.isGameOver) { gm.isStart = true; move.StartJump(); }
        }
    }

    // Ver3 : ��ǲ �߿� ���������� ���� ���, AddForce�ÿ��� �ڷ�ƾ���� �����ϰ�, velocity ��� �ÿ��� ���� �������� �ʾƵ� ��.
    public void MouseClick_multi()
    {
        if (Input.GetMouseButtonDown(0))
        {
            input = true;
            Debug.Log(input);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            input = false;
            Debug.Log(input);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            gm.isStart = false;
            gm.isGameOver = true;
        }
    }
}
