using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class Hero : AbstractCharacter
    {
        protected float ShortRangeAttackPoints;
        protected float LongRangeAttackPoints;

        public Boss1 boss1;

        protected Hero()
        {
            MovingSpeed = 5f;
            JumpForce = 6f;
            ShortRangeAttackPoints = 20f;
            LongRangeAttackPoints = 5f;
            AttackDelayInSeconds = 1f;
            MaxHealthPoints = 6f;
        }

        new void Awake()
        {
            base.Awake();
            // boss = GameObject.Find("Boss1").GetComponent<Boss1>();
        }

        new void Start()
        {
            base.Start();
        }

        new void Update()
        {
            base.Update();

            CheckMove();
            CheckAttack();
        }

        void CheckAttack()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Attack();
            }
        }

        void CheckMove()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Move(Vector3.right);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move(Vector3.left);
            }
        }

        protected void Attack()
        {
            if (CanAttack)
            {
                boss1.LooseHp(ShortRangeAttackPoints);
                HandleAttackDone();
            }
        }

        protected void ShortRangeAttack()
        {

        }

        protected void LongRangeAttack()
        {

        }
    }
}