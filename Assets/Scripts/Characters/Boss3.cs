using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using Random = UnityEngine.Random;

namespace Characters
{
    
    
    public class Boss3 : AbstractBoss
    {
        private Vector3 m_MoveDirection = Vector3.left;
        private float m_ChangeMoveDirectionDelayInSeconds;
        
        private LayerMask m_WallLayer;
        private readonly float m_SideHitDistance = 0.1f;

        private const float CollisionBodyAttack = 1f;
        
        protected Boss3()
        {
            JumpForce = 15f;
            MovingSpeed = 4f;
            AttackDelayInSeconds = 5f;
            MaxHealthPoints = 400f;
        }

        new void Awake()
        {
            base.Awake();
            m_WallLayer = LayerMask.GetMask("Walls");
        }

        new void Start()
        {
            base.Start();
        }

        new void Update()
        {
            base.Update();

            Move(m_MoveDirection);
            
            Attack();
        }

        private void Attack()
        {
            if (!CanAttack)
            {
                return;
            }


            if(Phase == 2)
            {
                // todo delete platforms
            }

            HandleAttackDone();
        }
        
        
        private bool IsHittingLeft()
        {
            var halfSpriteWidth = SpriteRenderer.bounds.size.x/2;
            var leftSpritePosition = transform.position + (Vector3.left * halfSpriteWidth);
        
            var hitLeft = Physics2D.Raycast(
                leftSpritePosition, 
                Vector2.left, 
                m_SideHitDistance,
                m_WallLayer
            );

            return hitLeft.collider;
        }
        
        private bool IsHittingRight()
        {
            var halfSpriteWidth = SpriteRenderer.bounds.size.x/2;
            var rightSpritePosition = transform.position + (Vector3.right * halfSpriteWidth);
        
            var hitRight = Physics2D.Raycast(
                rightSpritePosition, 
                Vector2.right, 
                m_SideHitDistance,
                m_WallLayer
            );

            return hitRight.collider;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (IsHittingLeft())
            {
                m_MoveDirection = Vector3.right;
            } 
            if(IsHittingRight())
            {
                m_MoveDirection = Vector3.left;
            }

            if (col.gameObject.CompareTag("Hero"))
            {
                hero.LooseHp(CollisionBodyAttack);
            }
        }

        protected override void HandleDeath()
        {
            SceneManager.LoadScene("GameWon");
        }
    }
}
