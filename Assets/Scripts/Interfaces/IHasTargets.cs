using System.Collections.Generic;

namespace Interfaces
{
    public interface IHasTargets
    {
        public abstract List<int> GetTargets();
        public abstract List<int> GetCollidingTargets();
    }
}