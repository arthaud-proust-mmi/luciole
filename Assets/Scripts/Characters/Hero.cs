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
            ShortRangeAttackPoints = 20f;
            LongRangeAttackPoints = 5f;
            MaxHealthPoints = 6f;
            JumpHeight = 7f;
            AttackDelayInSeconds = 0;
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

            if (Input.GetKeyDown(KeyCode.E))
            {
                Attack();
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