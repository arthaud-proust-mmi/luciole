using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBoss : AbstractCharacter
{
    protected int Phase = 0;
    protected bool CanAttack = true;
    protected int AttackDelayInSeconds;
    
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

    public void NextPhase()
    {
        Phase++;
    }

    public void LooseHp(int hpCount)
    {
        HealthPoints -= hpCount;
        if (IsDead())
        {
            HandleDeath();
        }
        else
        {
            NextPhaseIfUnderHalfLife();
        }
    }

    protected void NextPhaseIfUnderHalfLife()
    {
        if (HealthPoints < MaxHealthPoints / 2)
        {
            NextPhase();
        }
    }

    protected override void HandleDeath()
    {
    }
    
    protected void HandleAttackDone()
    {
        CanAttack = false;
        StartCoroutine(ApplyAttackDelay());
    }
    IEnumerator ApplyAttackDelay()
    {
        yield return new WaitForSeconds(AttackDelayInSeconds);
        CanAttack = true;
    }
}
