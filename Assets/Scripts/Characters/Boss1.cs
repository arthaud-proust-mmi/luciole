using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

namespace Characters
{
    public class Boss1 : AbstractBoss
    {
        public GameObject chocWavePrefab;
        public GameObject stalactitePrefab;

        private bool m_IsJumpingToPrimaryAttack = false;

        protected Boss1()
        {
            JumpForce = 3f;
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

            Attack();

            ContinuePrimaryAttackIfTouchingGround();
        }

        protected override void RandomMove()
        {
        }

        private void Attack()
        {
            if (!CanAttack)
            {
                return;
            }

            PrimaryAttack();

            if(Phase == 2)
            {
                SecondaryAttack();
            }

            HandleAttackDone();
        }

        private void PrimaryAttack()
        {
            Jump();
            m_IsJumpingToPrimaryAttack = true;
        }

        private void ContinuePrimaryAttackIfTouchingGround()
        {
            var isFalling = m_Rb2D.velocity.y < 0;
            if (m_IsJumpingToPrimaryAttack && IsHittingDown() && isFalling)
            {
                FinalisePrimaryAttack();
            }
        }

        private void FinalisePrimaryAttack()
        {
            m_IsJumpingToPrimaryAttack = false;
            
            Vector3 projectilePosition = new Vector3(
                transform.position.x,
                0f,
                transform.position.z
            );
            
            GameObject.Instantiate(
                chocWavePrefab, 
                projectilePosition, 
                chocWavePrefab.transform.rotation
            );
        }

        private void SecondaryAttack()
        {
            
            for (var x = -15f; x < 15f; x+=2f)
            {
                var randomY = Random.Range(11.0f, 14.0f);

                GenerateStalactiteAtPosition(new Vector3(
                    x,
                    randomY,
                    0f
                ));
            }
        }

        private void GenerateStalactiteAtPosition(Vector3 projectilePosition)
        {
            GameObject.Instantiate(
                stalactitePrefab, 
                projectilePosition, 
                stalactitePrefab.transform.rotation
            ); 
        }

        protected override void HandleDeath()
        {
            SceneManager.LoadScene("GameWon");
        }
    }
}
