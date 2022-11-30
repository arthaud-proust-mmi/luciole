using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBoss : AbstractCharacter
{
    protected int Phase = 1;

    public Characters.Hero hero;
    

    protected abstract void RandomMove();
    protected abstract void RandomAttack();
    
    new void Awake()
    {
        base.Awake();
        // Hero = GameObject.FindWithTag("Hero").GetComponent<Hero>();
    }
    
    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
    }

    private void PhaseTwoIfUnderHalfLife()
    {
        if (Phase == 1 && HealthPoints < MaxHealthPoints / 2)
        {
            Phase = 2;
            Debug.Log("Phase 2 started");
        }
    }
    
    protected override void HandleHpLost()
    {
        PhaseTwoIfUnderHalfLife();
    }
    
    protected override void HandleDeath()
    {
        Destroy(gameObject);
        Destroy(hpText);
    }
}
