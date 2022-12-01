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
        private Vector3 m_MoveDirection = Vector3.right;
        private float m_ChangeMoveDirectionDelayInSeconds;
        private bool m_CanChangeMoveDirection;
        
        private LayerMask m_WallLayer;
        private readonly float m_SideHitDistance = 0.1f;

        
        protected Boss3()
        {
            JumpForce = 3f;
            MovingSpeed = 5f;
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

            // RandomChangeMoveDirection();
            Move(m_MoveDirection);
            
            Attack();
        }

        private void RandomChangeMoveDirection()
        {
            if (!m_CanChangeMoveDirection)
            {
                return;
            }
            
            m_MoveDirection = (Random.Range(0f, 1f) > 0.5f) ? Vector3.left : Vector3.right;

            HandleChangeMoveDirectionDone();
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
            var halfSpriteWidth = SpriteRenderer.bounds.size.y/2;
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
            var halfSpriteWidth = SpriteRenderer.bounds.size.y/2;
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
            Debug.Log("trigger");
            if (IsHittingLeft())
            {
                Debug.Log("triggerLeft");

                m_MoveDirection = Vector3.right;
            } 
            if(IsHittingRight())
            {
                Debug.Log("triggerRight");
                m_MoveDirection = Vector3.left;
            }
        }


        protected override void HandleDeath()
        {
            SceneManager.LoadScene("GameWon");
        }
        
        protected void HandleChangeMoveDirectionDone()
        {
            m_CanChangeMoveDirection = false;
            StartCoroutine(ApplyChangeMoveDirectionDelay());
        }
    
        IEnumerator ApplyChangeMoveDirectionDelay()
        {
            yield return new WaitForSeconds(m_ChangeMoveDirectionDelayInSeconds);
            m_CanChangeMoveDirection = true;
        }
    }
}
