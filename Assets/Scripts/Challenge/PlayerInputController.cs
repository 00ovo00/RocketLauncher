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

    // OnXXX �޼ҵ�� ����� �Է� �����͸� ����ȭ ���� ��ó�� ��ġ��
    // ���� ��ü�� TopDownController�� ����
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;    // ������ �Է��� ����ȭ
        CallMoveEvent(moveInput);   // ����ȭ�� �Է� ���� �̺�Ʈ �޼ҵ�� ����
    }
}
