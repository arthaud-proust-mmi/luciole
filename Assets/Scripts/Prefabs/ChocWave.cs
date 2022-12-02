using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace Prefabs
{
    public class ChocWave: AffectingSprite
    {
        private const float ChocWaveDamage = 1f;
        public override bool IsCharacterATarget(AbstractCharacter character)
        {
            return character.GetType() == typeof(Hero);
        }

        public override void AffectTargetCharacter(AbstractCharacter character)
        {
            character.LooseHp(ChocWaveDamage);
        }
    }
}