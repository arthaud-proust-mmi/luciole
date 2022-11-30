using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Boss1 : AbstractBoss
{
    protected float PrimaryAttackPoints;
    protected float SecondaryAttackPoints;
    
    protected Boss1()
    {
        PrimaryAttackPoints = 1f;
        SecondaryAttackPoints = 0.5f;
        AttackDelayInSeconds = 5;
        MaxHealthPoints = 200f;
    }
    
    new void Awake()
    {
        base.Awake();
    }

    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
        
        RandomAttack();
    }

    protected override void RandomMove()
    {
    }
    
    protected override void RandomAttack()
    {
        if (CanAttack)
        {
            Debug.Log("Attack hero");
            if (Random.value < 0.5f)
            {
                PrimaryAttack();
            }
            else
            {
                SecondaryAttack();
            }

            HandleAttackDone();
        }
    }

    public void PrimaryAttack()
    {
        hero.LooseHp(PrimaryAttackPoints);
    }
    
    public void SecondaryAttack()
    {
        hero.LooseHp(SecondaryAttackPoints);
    }
}
