using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace Characters
{
    public class Boss1 : AbstractBoss
    {
        protected float PrimaryAttackPoints;
        protected float SecondaryAttackPoints;

        public GameObject chocWavePrefab;

        protected Boss1()
        {
            PrimaryAttackPoints = 1f;
            SecondaryAttackPoints = 0.5f;
            AttackDelayInSeconds = 5;
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
            Vector3 projectilePosition = new Vector3(
                transform.position.x,
                0.5f,
                transform.position.z
            );
            var projectile = GameObject.Instantiate(
                    chocWavePrefab, 
                    projectilePosition, 
                    chocWavePrefab.transform.rotation
                    );
        }

        public void SecondaryAttack()
        {
            hero.LooseHp(SecondaryAttackPoints);
        }
    }
}
