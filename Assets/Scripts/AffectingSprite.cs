
using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public abstract class AffectingSprite: AbstractSprite
{
    public Vector2 startingVelocity;
    private Rigidbody2D m_Rb2D;

    public abstract bool IsCharacterATarget(AbstractCharacter character);

    public abstract void AffectTargetCharacter(AbstractCharacter character);

    public new void Awake()
    {
        base.Awake();
        m_Rb2D = GetComponent<Rigidbody2D>();
    }
    
    public new void Start()
    {
        base.Start();
        m_Rb2D.velocity = startingVelocity;
    }

    public new void Update()
    {
        base.Update();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Characters"))
        {
            HandleTriggerWithCharacter(col);
        }
    }
    
    private void HandleTriggerWithCharacter(Collider2D col)
    {
        var character = col.gameObject.GetComponent<AbstractCharacter>();
        if (IsCharacterATarget(character))
        {
            AffectTargetCharacter(character);
        } 
    }
}