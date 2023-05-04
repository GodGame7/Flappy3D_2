using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool input = false;
    private void Update()
    {
        MouseClick_multi(); //Ver3
    }


    // Ver1. 모바일 터치
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


    // Ver2 : Update문에 넣으면 인풋 중 계속 실행, 이벤트로 실행 시 1번 위로 상승.
    public void MouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Click");
        }
    }

    // Ver3 : 인풋 중에 지속적으로 위로 상승, AddForce시에는 코루틴으로 제어하고, velocity 사용 시에는 굳이 제어하지 않아도 됨.
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

}
