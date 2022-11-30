using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace Prefabs
{
    public class Flower: AffectingSprite
    {
        private float m_FlowerDamage = 5f;
        
        public override bool IsCharacterATarget(AbstractCharacter character)
        {
            return character.GetType().Name == "Boss1";
        }

        public override void AffectTargetCharacter(AbstractCharacter character)
        {
            character.LooseHp(m_FlowerDamage);

            Destroy(gameObject);
        }
    }
}