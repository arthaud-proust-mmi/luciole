using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : AbstractCharacter
{
    protected int ShortRangeAttackPoints;
    protected int LongRangeAttackPoints;
    
    protected Hero()
    {
        ShortRangeAttackPoints = 20;
        LongRangeAttackPoints = 5;
        MaxHealthPoints = 6;
        JumpHeight = 7f;
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
    }

    void Attack()
    {
        
    }

    protected override void HandleDeath()
    {
        
    }
}
