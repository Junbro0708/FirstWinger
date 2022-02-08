using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    [SerializeField]
    Vector3 moveVector = Vector3.zero;

    [SerializeField]
    float Speed;

    [SerializeField]
    BoxCollider boxCollider;

    [SerializeField]
    Transform mainBGQuadTranform;

    [SerializeField]
    Transform FireTransform;

    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    float bulletSpeed = 1f;

    void Start()
    {
        
    }

    protected override void UpdateActor()
    {
        UpdateMove();
    }

    void UpdateMove()
    {
        if (moveVector.sqrMagnitude == 0)
            return;

        moveVector = AdjustMoveVector(moveVector);

        transform.position += moveVector;
    }

    public void ProcessInput(Vector3 moveDirection)
    {
        moveVector = moveDirection * Speed * Time.deltaTime;
    }

    Vector3 AdjustMoveVector(Vector3 moveVector)
    {
        Vector3 result = Vector3.zero;
        result = boxCollider.transform.position + moveVector;
        Debug.Log(boxCollider.center);

        if (result.x - boxCollider.size.x * 0.5f < -mainBGQuadTranform.localScale.x * 0.5f)
            moveVector.x = 0;
        if (result.x + boxCollider.size.x * 0.5f > mainBGQuadTranform.localScale.x * 0.5f)
            moveVector.x = 0;

        if (result.y - boxCollider.size.y * 0.5f < -mainBGQuadTranform.localScale.y * 0.5f)
            moveVector.y = 0;
        if (result.y + boxCollider.size.y * 0.5f > mainBGQuadTranform.localScale.y * 0.5f)
            moveVector.y = 0;

        return moveVector;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (enemy)
        {
            if (!enemy.IsDead)
                enemy.OnCrash(this, CrashDamage);
        }
    }

    public override void OnCrash(Actor attacker, int damage)
    {
        base.OnCrash(attacker, damage);
    }

    public void Fire()
    {
        GameObject go = Instantiate(Bullet);
        Bullet bullet = go.GetComponent<Bullet>();

        bullet.Fire(OwnerSide.Player, FireTransform.position, FireTransform.right, bulletSpeed, damage);
    }
}
