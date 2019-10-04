using System;
using System.Collections.Generic;
using System.Text;
using static Beliefs_desires_intentions_Agent_Architecture.EnumTypes;

namespace Beliefs_desires_intentions_Agent_Architecture
{
    // Bdi<T> class simply provide a map(abstract versions of Deliberate and MeansEndsReasoning methods) for creating BDI models.
    public abstract class Bdi<T>
    {
        public IEnumerable<Attitude<BeliefType, T>> Beliefs { get; set; }
        public IEnumerable<Attitude<DesireType, T>> Desires { get; set; }
        public IEnumerable<Attitude<DesireType, T>> Intentions { get; set; }
        protected Bdi(IEnumerable<Attitude<BeliefType, T>> beliefs)
        {
            Beliefs = new List<Attitude<BeliefType, T>>(beliefs);
            Desires = new List<Attitude<DesireType, T>>();
            Intentions = new List<Attitude<DesireType, T>>();
        }
        protected abstract IEnumerable<Attitude<IntentionType, T>> Deliberate(
          IEnumerable<Attitude<DesireType, T>> desires);
        protected abstract T MeansEndsReasoning(IEnumerable<Attitude<IntentionType,
          T>> intentions);
    }
}
