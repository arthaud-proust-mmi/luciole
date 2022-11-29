using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacter : AbstractSprite
{
    protected float HealthPoints;
    protected float MaxHealthPoints;
    protected float JumpHeight;
    
    protected bool CanAttack = true;
    protected int AttackDelayInSeconds;
    
    private LayerMask m_GroundLayer;

    private Rigidbody2D m_Rb2D;
    private readonly float m_BottomHitDistance = 1f;
    
    protected abstract void HandleDeath();

    public void Awake()
    {
        m_GroundLayer = LayerMask.GetMask("Ground");
        m_Rb2D = GetComponent<Rigidbody2D>();
        ResetLife();
    }
    
    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (IsHittingDown())
        {
            m_Rb2D.velocity = Vector2.up * JumpHeight;
        }
    }

    public void ResetLife()
    {
        HealthPoints = MaxHealthPoints;
    }
    
    public bool IsHittingDown()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(
            transform.position, 
            Vector2.down, 
            m_BottomHitDistance,
            m_GroundLayer
        );

        return hitDown.collider;
    }

    public bool IsDead()
    {
        return HealthPoints <= 0;
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
