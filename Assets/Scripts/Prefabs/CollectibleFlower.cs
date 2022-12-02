using System.Collections.Generic;
using Characters;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prefabs
{
    public class CollectibleFlower: AffectingSprite
    {
        public override bool IsCharacterATarget(AbstractCharacter character)
        {
            return character.GetType() == typeof(Hero);
        }

        public override void AffectTargetCharacter(AbstractCharacter character)
        {
            LoadNextScene();
        }

        private void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}