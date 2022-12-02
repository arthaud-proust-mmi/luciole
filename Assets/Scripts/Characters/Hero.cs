using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Characters
{
    public class Hero : AbstractCharacter
    {
        protected float ShortRangeAttackPoints;
        
        public GameObject flowerPrefab;
        
        public bool canShortRangeAttack = true;
        public bool canLongRangeAttack = true;

        protected Hero()
        {
            MovingSpeed = 5f;
            JumpForce = 25f;
            ShortRangeAttackPoints = 20f;
            AttackDelayInSeconds = 1f;
            MaxHealthPoints = 6f;
        }

        new void Awake()
        {
            base.Awake();
            // boss = GameObject.Find("Boss1").GetComponent<AbstractBoss>();
        }

        new void Start()
        {
            base.Start();
        }

        new void Update()
        {
            base.Update();

            CheckMove();
            CheckJump();
            CheckAttack();
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

        void CheckJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        
        void CheckAttack()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                ShortRangeAttack();
            }
            
            if (Input.GetKeyDown(KeyCode.V))
            {
                LongRangeAttack();
            }
        }

        protected override void HandleDeath()
        {
            SceneManager.LoadScene("GameLost");
        }

        protected void ShortRangeAttack()
        {
            if (!CanAttack || !canShortRangeAttack)
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

                if (characterHit && characterHit.GetType().IsSubclassOf(typeof(AbstractBoss)))
                {
                    characterHit.LooseHp(ShortRangeAttackPoints);
                }
            }

            HandleAttackDone();
        }

        protected void LongRangeAttack()
        {
            if (!CanAttack || !canLongRangeAttack)
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