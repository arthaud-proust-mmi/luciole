using System.Collections.Generic;

namespace Interfaces
{
    public interface IHasTargets
    {
        public abstract List<AbstractCharacter> GetTargets();
        public abstract List<AbstractCharacter> GetCollidingTargets();
    }
}