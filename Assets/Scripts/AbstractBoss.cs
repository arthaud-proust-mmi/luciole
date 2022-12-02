using System.Collections;
using System.Collections.Generic;
using Prefabs;
using UnityEngine;

public abstract class AbstractBoss : AbstractCharacter
{
    protected int Phase = 1;

    public Characters.Hero hero;
    public GameObject dropFlowerPrefab;
    
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
    
    public override void Move(Vector3 directionVector)
    {
        SpriteRenderer.flipX = directionVector.x > 0;

        transform.position += Time.deltaTime * MovingSpeed * directionVector;
    }

    private void BeginPhaseTwoIfUnderHalfLife()
    {
        if (Phase == 1 && HealthPoints < MaxHealthPoints / 2)
        {
            Phase = 2;
            HandlePhaseTwoBegan();
            Debug.Log("Phase 2 started");
        }
    }
    
    protected void DropFlower()
    {
        var flowerPosition = new Vector3(
            transform.position.x,
            1f,
            transform.position.z
        );
        
        Instantiate(
            dropFlowerPrefab,
            flowerPosition,
            dropFlowerPrefab.transform.rotation
        );
    }

    protected virtual void HandlePhaseTwoBegan()
    {
        
    }
    
    protected override void HandleHpLost()
    {
        BeginPhaseTwoIfUnderHalfLife();
    }
    
    protected override void HandleDeath()
    {
        Destroy(gameObject);
        Destroy(hpText);
        DropFlower();
    }
}
