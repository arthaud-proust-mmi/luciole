using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Boss1 : AbstractBoss
{
    protected Boss1()
    {
        AttackDelayInSeconds = 5;
        MaxHealthPoints = 200;
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
        if (!CanAttack)
        {
            return;
        }
        
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

    public void PrimaryAttack()
    {
        Debug.Log("primary attack");
    }
    
    public void SecondaryAttack()
    {
        Debug.Log("secondary attack");
    }
}
