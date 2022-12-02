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

        private const float AttackPoints = 1f;
        
        protected Animator Animator;
        
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
            Animator = GetComponent<Animator>();
        }

        new void Start()
        {
            base.Start();
        }

        new void Update()
        {
            base.Update();

            ChangeDirectionIfWallCollided();
            
            Move(m_MoveDirection);

            if (Phase == 1 && CanAttack)
            {
                Animator.SetBool("IsAttacking", true);
                ShortRangeAttack();
                HandleAttackDone();
            }
            
        }

        private void ChangeDirectionIfWallCollided()
        {
            if (IsHittingWallLeft())
            {
                m_MoveDirection = Vector3.right;
            } 
            if(IsHittingWallRight())
            {
                m_MoveDirection = Vector3.left;
            }
        }

        private void ShortRangeAttack()
        {
            var hitGameObjectList = Physics2D.CircleCastAll(
                transform.position,
                2f,
                Vector2.zero
            );

            foreach (var hitGameObject in hitGameObjectList)
            {
                AttackCollided(hitGameObject.collider);
            }
        }
        
        
        private bool IsHittingWallLeft()
        {
            var bc2DBounds = BoxCollider2D.bounds;
            var halfSpriteWidth = bc2DBounds.size.x/2;
            var leftSpritePosition = bc2DBounds.center + (Vector3.left * halfSpriteWidth);
        
            var hitLeft = Physics2D.Raycast(
                leftSpritePosition, 
                Vector2.left, 
                m_SideHitDistance,
                m_WallLayer
            );
            
            Debug.DrawRay(leftSpritePosition, Vector3.left * m_SideHitDistance);

            return hitLeft.collider;
        }
        
        private bool IsHittingWallRight()
        {
            var bc2DBounds = BoxCollider2D.bounds;
            var halfSpriteWidth = bc2DBounds.size.x/2;
            var rightSpritePosition = bc2DBounds.center + (Vector3.right * halfSpriteWidth);
            var hitRight = Physics2D.Raycast(
                rightSpritePosition, 
                Vector2.right, 
                m_SideHitDistance,
                m_WallLayer
            );
            
            Debug.DrawRay(rightSpritePosition, Vector3.right * m_SideHitDistance);


            return hitRight.collider;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (Phase == 2)
            {
                AttackCollided(col);
            }
        }

        private void AttackCollided(Collider2D col)
        {
            var characterHit = col.gameObject.GetComponent<AbstractCharacter>();
            if (characterHit && characterHit.GetType() == typeof(Hero))
            {
                hero.LooseHp(AttackPoints);
            }
        }

        protected override void HandlePhaseTwoBegan()
        {
            Animator.SetBool("IsAngry", true);
        }
        
        protected override void HandleAttackDone()
        {
            CanAttack = false;
            Animator.SetBool("IsAttacking", false);
            StartCoroutine(ApplyAttackDelay());
        }
     
        protected override IEnumerator ApplyAttackDelay()
        {
            yield return new WaitForSeconds(AttackDelayInSeconds);
            CanAttack = true;
        }
    }
}
