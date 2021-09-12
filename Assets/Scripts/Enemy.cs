using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        None = -1, // 사용전
        Ready = 0, // 준비완료
        Appear, // 등장
        Battle, // 전투중
        Dead, // 사망
        Disappear, // 퇴장
    }

    [SerializeField]
    State CurrentState = State.None;

    const float MaxSpeed = 10.0f; // 최대 속도
    const float MaxSpeedTime = 0.5f; // 자연스러운 가속

    [SerializeField]
    Vector3 TargetPosition;

    [SerializeField]
    float currentSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void UpdateSpeed()
    {

    }

    void UpdateMove()
    {

    }

    void Arrived()
    {

    }

    public void Appear(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        currentSpeed = MaxSpeed;
        CurrentState = State.Appear;
    }

    void Disappear(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        currentSpeed = MaxSpeed;
        CurrentState = State.Disappear;
    }
}
