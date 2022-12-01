using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace Prefabs
{
    public class Stalactite: AffectingSprite
    {
        private const float FallingDecorationDamage = 0.5f;
        
        public override bool IsCharacterATarget(AbstractCharacter character)
        {
            return character.GetType().Name == "Hero";
        }

        public override void AffectTargetCharacter(AbstractCharacter character)
        {
            character.LooseHp(FallingDecorationDamage);

            Destroy(gameObject);
        }
    }
}