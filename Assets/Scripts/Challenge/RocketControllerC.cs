using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControllerC : MonoBehaviour
{
    private EnergySystemC _energySystem;
    private RocketMovementC _rocketMovement;
    
    private bool _isMoving;
    private float _movementDirection;
    
    private readonly float ENERGY_TURN = 0.5f;  // 회전에 소모되는 연료량
    private readonly float ENERGY_BURST = 2f;   // 부스트에 소모되는 연료량

    // 스페이스바 더블탭 추적
    private float _lastBoostTime;   // 마지막으로 스페이스바 눌린 시각
    private readonly float _doublePressDelay = 0.3f;    // 더블탭 인정 시간

    private void Awake()
    {
        _energySystem = GetComponent<EnergySystemC>();
        _rocketMovement = GetComponent<RocketMovementC>();
    }
    
    private void FixedUpdate()
    {
        // 움직임 없거나 연료 없으면 바로 리턴
        if (!_isMoving) return;
        if(!_energySystem.UseEnergy(Time.fixedDeltaTime * ENERGY_TURN)) return;
        
        // 움직이는 상태이고 연료 있으면 실행됨
        // 로켓의 실제 움직임 실행
        _rocketMovement.ApplyMovement(_movementDirection);
    }
    // A, D 키 이용한 좌우 이동
    private void OnMove(InputValue value)
    {
        Vector2 movementInput = value.Get<Vector2>();   // InputSystem으로 Vector 입력받기
        _movementDirection = movementInput.x;   // x(수평)좌표만 추출
        _isMoving = MathF.Abs(_movementDirection) > 0;  // 이동 있으면 이동 상태로 전환
    }
    // 스페이스바 더블탭으로 상승 이동
    private void OnBoost()
    {
        float currentTime = Time.time;
        // 스페이스바 더블탭 눌렸는지 확인
        if (currentTime - _lastBoostTime < _doublePressDelay)
        {
            // 연료 사용하며 부스트 적용
            if (_energySystem.UseEnergy(ENERGY_BURST))
            {
                _rocketMovement.ApplyBoost();
            }
        }
        _lastBoostTime = currentTime;   // 마지막 부스트 시각 갱신
    }
}