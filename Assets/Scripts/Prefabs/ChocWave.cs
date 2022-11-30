using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace Prefabs
{
    public class ChocWave: AffectingSprite
    {
        public override bool IsCharacterATarget(AbstractCharacter character)
        {
            return character.GetType().Name == "Hero";
        }

        public override void AffectTargetCharacter(AbstractCharacter character)
        {
            character.LooseHp(2f);
            
            Destroy(gameObject);
        }
    }
}