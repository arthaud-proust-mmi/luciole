using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

namespace Characters
{
    public class Boss1 : AbstractBoss
    {
        protected float SecondaryAttackPoints;

        public GameObject chocWavePrefab;

        private bool m_IsJumpingToPrimaryAttack = false;

        protected Boss1()
        {
            JumpForce = 3f;
            SecondaryAttackPoints = 0.5f;
            AttackDelayInSeconds = 5f;
            MaxHealthPoints = 200f;
        }

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

            RandomAttack();

            if (m_IsJumpingToPrimaryAttack && IsHittingDown() && (m_Rb2D.velocity.y < 0))
            {
                PrimaryAttackOnTouchingGround();
            }
        }

        protected override void RandomMove()
        {
        }

        protected override void RandomAttack()
        {
            if (CanAttack)
            {
                Debug.Log("Attack hero");
                PrimaryAttack();

                if (Random.value < 0.5f)
                {
                }

                HandleAttackDone();
            }
        }

        public void PrimaryAttack()
        {
            Jump();
            m_IsJumpingToPrimaryAttack = true;
        }

        public void PrimaryAttackOnTouchingGround()
        {
            m_IsJumpingToPrimaryAttack = false;
            
            Vector3 projectilePosition = new Vector3(
                transform.position.x,
                1f,
                transform.position.z
            );
            
            GameObject.Instantiate(
                chocWavePrefab, 
                projectilePosition, 
                chocWavePrefab.transform.rotation
            );
        }

        public void SecondaryAttack()
        {
            hero.LooseHp(SecondaryAttackPoints);
        }

        protected override void HandleDeath()
        {
            SceneManager.LoadScene("GameWon");
        }
    }
}
