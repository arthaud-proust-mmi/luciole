using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBoss : AbstractCharacter
{
    protected int Phase = 1;

    protected abstract void RandomMove();
    protected abstract void RandomAttack();
    
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

    public void LooseHp(int hpCountToLoose)
    {
        if (IsDead())
        {
            return;
        }
        
        HealthPoints -= hpCountToLoose;
        
        if (IsDead())
        {
            HandleDeath();
        }
        else
        {
            HandleHpLost();
            PhaseTwoIfUnderHalfLife();
        }
    }

    protected void PhaseTwoIfUnderHalfLife()
    {
        if (Phase == 1 && HealthPoints < MaxHealthPoints / 2)
        {
            Phase = 2;
            Debug.Log("Phase 2 started");
        }
    }

    protected void HandleHpLost()
    {
        Debug.Log(HealthPoints);
    }
    
    protected override void HandleDeath()
    {
        Debug.Log("Boss dead");
    }
}
