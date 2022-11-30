using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class AbstractCharacter : AbstractSprite
{
    private float _healthPoints;
    public float HealthPoints
    {
        get
        {
            return _healthPoints;
        }

        set
        {
            _healthPoints = value;
            
            string className = GetType().Name;
            hpText.SetText($"{className} HP: {_healthPoints}");
        }
    }
    protected float MaxHealthPoints;
    protected float JumpHeight;
    
    protected bool CanAttack = true;
    protected int AttackDelayInSeconds;
    
    private LayerMask m_GroundLayer;

    private Rigidbody2D m_Rb2D;
    private readonly float m_BottomHitDistance = 1f;

    public TMP_Text hpText; 
    
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


    
    public void LooseHp(float hpCountToLoose)
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
    
    protected void HandleHpLost()
    {
        string className = GetType().Name;
        Debug.LogWarning($"Character {className} lost HP (now at {HealthPoints}), not Handled");
    }
    
    protected void HandleDeath()
    {
        string className = GetType().Name;
        Debug.LogWarning($"Character {className} dead, not handled");
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
