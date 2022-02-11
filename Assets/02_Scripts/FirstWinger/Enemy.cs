using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public enum State : int
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

    Vector3 currentVelocity;
    float startMoveTime = 0.0f;

    [SerializeField]
    Transform FireTransform;

    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    float bulletSpeed = 1f;

    float lastBattleUpdateTime = 0.0f;

    [SerializeField]
    int fireRemainCount = 1;

    int gamePoint = 1;

    protected override void UpdateActor()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Disappear(new Vector3(-15.0f, 0.0f, 0.0f));
        }

        switch (CurrentState)
        {
            case State.None:
            case State.Ready:
                break;
            case State.Dead:
                break;
            case State.Appear:
            case State.Disappear:
                UpdateSpeed();
                UpdateMove();
                break;
            case State.Battle:
                UpdateBattle();
                break;
        }
    }

    void UpdateSpeed()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, MaxSpeed, (Time.time - startMoveTime) / MaxSpeedTime);
    }

    void UpdateMove()
    {
        float distance = Vector3.Distance(TargetPosition, transform.position);
        if(distance == 0)
        {
            Arrived();
            return;
        }

        currentVelocity = (TargetPosition - transform.position).normalized * currentSpeed;

        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref currentVelocity, distance / currentSpeed, MaxSpeed);
    }

    void Arrived()
    {
        currentSpeed = 0.0f;
        if(CurrentState == State.Appear)
        {
            CurrentState = State.Battle;
            lastBattleUpdateTime = Time.time;
        }else //if(CurrentState == State.Disappear)
        {
            CurrentState = State.None;
        }
    }

    public void Appear(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        currentSpeed = MaxSpeed;

        CurrentState = State.Appear;
        startMoveTime = Time.time;
    }

    void Disappear(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        currentSpeed = 0.0f;

        CurrentState = State.Disappear;
        startMoveTime = Time.time;
    }

    void UpdateBattle()
    {
        if(Time.time - lastBattleUpdateTime > 1.0f)
        {
            if(fireRemainCount > 0)
            {
                Fire();
                fireRemainCount--;
            }
            else
            {
                Disappear(new Vector3(-15.0f, transform.position.y, transform.position.z));
            }
            lastBattleUpdateTime = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();
        if (!player)
            player.OnCrash(this, CrashDamage);
    }

    public void OnCrash(Player player)
    {
        Debug.Log("OnCrash player = " + player);
    }

    public void Fire()
    {
        GameObject go = Instantiate(Bullet);
        Bullet bullet = go.GetComponent<Bullet>();

        bullet.Fire(OwnerSide.Enemy, FireTransform.position, -FireTransform.right, bulletSpeed, damage);
    }

    protected override void OnDead(Actor killer)
    {
        base.OnDead(killer);

        SystemManager.Instance.GamePointAccumulator.Acuumulate(gamePoint);

        CurrentState = State.Dead;
    }
}
