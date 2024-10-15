using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControllerC : MonoBehaviour
{
    private EnergySystemC _energySystem;
    private RocketMovementC _rocketMovement;
    
    private bool _isMoving;
    private float _movementDirection;
    
    private readonly float ENERGY_TURN = 0.5f;  // ȸ���� �Ҹ�Ǵ� ���ᷮ
    private readonly float ENERGY_BURST = 2f;   // �ν�Ʈ�� �Ҹ�Ǵ� ���ᷮ

    // �����̽��� ������ ����
    private float _lastBoostTime;   // ���������� �����̽��� ���� �ð�
    private readonly float _doublePressDelay = 0.3f;    // ������ ���� �ð�

    private void Awake()
    {
        _energySystem = GetComponent<EnergySystemC>();
        _rocketMovement = GetComponent<RocketMovementC>();
    }
    
    private void FixedUpdate()
    {
        // ������ ���ų� ���� ������ �ٷ� ����
        if (!_isMoving) return;
        if(!_energySystem.UseEnergy(Time.fixedDeltaTime * ENERGY_TURN)) return;
        
        // �����̴� �����̰� ���� ������ �����
        // ������ ���� ������ ����
        _rocketMovement.ApplyMovement(_movementDirection);
    }
    // A, D Ű �̿��� �¿� �̵�
    private void OnMove(InputValue value)
    {
        Vector2 movementInput = value.Get<Vector2>();   // InputSystem���� Vector �Է¹ޱ�
        _movementDirection = movementInput.x;   // x(����)��ǥ�� ����
        _isMoving = MathF.Abs(_movementDirection) > 0;  // �̵� ������ �̵� ���·� ��ȯ
    }
    // �����̽��� ���������� ��� �̵�
    private void OnBoost()
    {
        float currentTime = Time.time;
        // �����̽��� ������ ���ȴ��� Ȯ��
        if (currentTime - _lastBoostTime < _doublePressDelay)
        {
            // ���� ����ϸ� �ν�Ʈ ����
            if (_energySystem.UseEnergy(ENERGY_BURST))
            {
                _rocketMovement.ApplyBoost();
            }
        }
        _lastBoostTime = currentTime;   // ������ �ν�Ʈ �ð� ����
    }
}