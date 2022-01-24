using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    protected int maxHP = 100;

    [SerializeField]
    protected int currentHP;

    [SerializeField]
    protected int damage = 1;

    [SerializeField]
    protected int crashDamage = 100;

    [SerializeField]
    bool isDead = false;

    public bool IsDead
    {
        get { return isDead; }
    }

    protected int CrashDamage
    {
        get { return crashDamage; }
    }

    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        UpdateActor();
    }

    protected virtual void UpdateActor()
    {
        
    }

    public virtual void OnBulletHitted(Actor attacker, int damage)
    {
        Debug.Log("OnBulletHitted damage = " + damage);
        DecreaseHP(attacker, damage);
    }

    public virtual void OnCrash(Actor attacker, int damage)
    {
        Debug.Log("OnCrash attacker = " + attacker.name + "OnCrash damage = " + damage);
        DecreaseHP(attacker, damage);
    }

    void DecreaseHP(Actor attacker, int value)
    {
        if (isDead) 
            return;

        currentHP -= value;

        if(currentHP < 0)
            currentHP = 0;

        if (currentHP == 0)
            OnDead(attacker);
    }

    protected virtual void OnDead(Actor killer)
    {
        Debug.Log(name + " OnDead");
        isDead = true;
    }
}
