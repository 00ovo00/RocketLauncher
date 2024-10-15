using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : RocketControllerC
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnXXX 메소드는 사용자 입력 데이터를 정규화 등의 전처리 마치고
    // 관리 주체인 TopDownController로 전달
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;    // 움직임 입력을 정규화
        CallMoveEvent(moveInput);   // 정규화한 입력 정보 이벤트 메소드로 전달
    }
}
