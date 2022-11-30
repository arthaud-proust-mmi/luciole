using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class Hero : AbstractCharacter
    {
        protected float ShortRangeAttackPoints;
        
        public GameObject flowerPrefab;

        public Boss1 boss1;

        protected Hero()
        {
            MovingSpeed = 5f;
            JumpForce = 6f;
            ShortRangeAttackPoints = 20f;
            AttackDelayInSeconds = 0.5f;
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                ShortRangeAttack();
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                LongRangeAttack();
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

        protected void ShortRangeAttack()
        {
            if (!CanAttack)
            {
                return;
            }

            var hitGameObjectList = Physics2D.CircleCastAll(
                transform.position,
                3f,
                Vector2.zero
            );

            foreach (var hitGameObject in hitGameObjectList)
            {
                var characterHit = hitGameObject.collider.gameObject.GetComponent<AbstractCharacter>();

                if (!characterHit)
                {
                    continue;
                }

                if (characterHit.GetType().Name == "Hero")
                {
                    continue;
                }
                
                characterHit.LooseHp(ShortRangeAttackPoints);
            }

            HandleAttackDone();
        }

        protected void LongRangeAttack()
        {
            if (!CanAttack)
            {
                return;
            }
            
            var halfSpriteHeight = SpriteRenderer.bounds.size.y/2;
            var topSpritePosition = transform.position + (Vector3.up * halfSpriteHeight);

            var projectile = GameObject.Instantiate(
                flowerPrefab, 
                topSpritePosition, 
                flowerPrefab.transform.rotation
            );

            HandleAttackDone();
        }
    }
}