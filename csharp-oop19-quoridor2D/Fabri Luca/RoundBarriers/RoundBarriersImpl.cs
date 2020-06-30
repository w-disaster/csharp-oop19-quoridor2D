using System.Collections;
using System.Collections.Generic;

namespace csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers
{
    public class RoundBarriersImpl : IRoundBarriers
    {
        private IList<IBarrier> barriers;

        public RoundBarriersImpl(IList<IBarrier> barriers)
        {
            this.barriers = barriers;
        }

        public RoundBarriersImpl() : this(new List<IBarrier>()){ }

        public void add(IBarrier barrier)
        {
            this.barriers.Add(barrier);
        }

        public bool contains(IBarrier barrier)
        {
            return this.barriers.Contains(barrier);
        }

        public IList<IBarrier> getBarriersAsList()
        {
            return this.barriers;
        }
    }
}