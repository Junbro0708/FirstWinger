using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OwnerSide : int
{
    Player = 0,
    Enemy
}

public class Bullet : MonoBehaviour
{
    const float lifeTime = 15.0f;

    OwnerSide ownerSide = OwnerSide.Player;

    [SerializeField]
    Vector3 MoveDirection = Vector3.zero;

    [SerializeField]
    float Speed = 0.0f;

    bool NeedMove = false;

    float firedTime;
    bool hitted = false;

    void Start()
    {

    }

    void Update()
    {
        if (ProcessDisappearCondition())
            return;

        UpdateMove();
    }

    void UpdateMove()
    {
        if (!NeedMove) return;

        Vector3 moveVector = MoveDirection.normalized * Speed * Time.deltaTime;
        AdjustMove(moveVector);
        transform.position += moveVector;
    }

    public void Fire(OwnerSide FireOwner, Vector3 firePosition, Vector3 direction, float speed)
    {
        ownerSide = FireOwner;
        transform.position = firePosition;
        MoveDirection = direction;
        Speed = speed;

        NeedMove = true;
        firedTime = Time.time;
    }

    Vector3 AdjustMove(Vector3 moveVector)
    {
        RaycastHit hitInfo;
        if (Physics.Linecast(transform.position, transform.position + moveVector, out hitInfo))
        {
            moveVector = hitInfo.point - transform.position;
            OnBulletCollision(hitInfo.collider);
            Debug.Log(hitInfo.collider.name);
        }
        return moveVector;
    }

    void OnBulletCollision(Collider collider)
    {
        if (hitted) return;

        Collider myCollider = GetComponentInChildren<Collider>();
        myCollider.enabled = false;

        hitted = true;
        NeedMove = false;

        if (ownerSide == OwnerSide.Player)
        {
            Enemy enemy = collider.GetComponentInParent<Enemy>();
        }
        else
        {
            Player player = collider.GetComponentInParent<Player>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        OnBulletCollision(other);
    }

    bool ProcessDisappearCondition()
    {
        if (transform.position.x > lifeTime || transform.position.x < -lifeTime || transform.position.y > lifeTime || transform.position.y < -lifeTime)
        {
            Disappear();
            return true;
        }
        else if(Time.time - firedTime > lifeTime)
        {
            Disappear();
            return true;
        }
        return false;
    }

    void Disappear()
    {
        Destroy(gameObject);
    }
}
