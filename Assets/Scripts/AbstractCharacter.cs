using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacter : AbstractSprite
{
    protected int HealthPoints;
    protected int MaxHealthPoints;
    protected float JumpHeight;
    
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D m_Rb2D;
    private readonly float m_BottomHitDistance = 1f;
    
    protected abstract void HandleDeath();

    public void Awake()
    {
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
            groundLayer
        );

        return hitDown.collider;
    }

    public bool IsDead()
    {
        return HealthPoints <= 0;
    }
}
