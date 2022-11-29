using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : AbstractCharacter
{
    protected int ShortRangeAttackPoints;
    protected int LongRangeAttackPoints;

    public  Boss1 boss1;
    
    protected Hero()
    {
        ShortRangeAttackPoints = 20;
        LongRangeAttackPoints = 5;
        MaxHealthPoints = 6f;
        JumpHeight = 7f;
    }
    
    new void Awake()
    {
        base.Awake();
    }
    
    new void Start()
    {
        base.Start();
        // boss = GameObject.Find("Boss1").GetComponent<Boss1>();
    }

    new void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    protected void Attack()
    {
        if (CanAttack)
        {
            boss1.LooseHp(ShortRangeAttackPoints);
            HandleAttackDone();
        }
    }

    protected void ShortRangeAttack()
    {
        
    }
    
    protected void LongRangeAttack()
    {
        
    }

    protected void LooseHalfHp()
    {
        HealthPoints -= 0.5f;
    }
    
    protected void LooseOneHp()
    {
        HealthPoints -= 1f;
    }
    protected void LooseTwoHp()
    {
        HealthPoints -= 2f;
    }

    protected override void HandleDeath()
    {
        
    }
}
