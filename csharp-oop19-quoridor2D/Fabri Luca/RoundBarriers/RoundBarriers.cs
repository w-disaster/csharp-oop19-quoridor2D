using System.Collections;
using System.Collections.Generic;
using csharp_oop19_quoridor2D.Fabri_Luca.Graph;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;

namespace csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers
{
    /// <summary>
    /// The round barriers class.
    /// </summary>
    public class RoundBarriers : IRoundBarriers
    {
        public static readonly int BoardDimension = 9;
        private IList<IBarrier> barriers;
        private IGraph<Coordinate> graph;

        public RoundBarriers(IList<IBarrier> barriers, IGraph<Coordinate> graph)
        {
            this.barriers = barriers;
            this.graph = graph;
        }

        public RoundBarriers() : this(new List<IBarrier>(), new BarriersGraph(RoundBarriers.BoardDimension)){ }

        public void Add(IBarrier barrier)
        {
            this.barriers.Add(barrier);
            foreach(var edge in BarriersGraph
                .BarriersAsEdgesToRemove(new List<IBarrier>() { barrier }))
            {
                this.graph.Remove(edge);
            }
        }

        public bool Contains(IBarrier barrier)
        {
            return this.barriers.Contains(barrier);
        }

        public IList<IBarrier> GetBarriersAsList()
        {
            return this.barriers;
        }

        public IGraph<Coordinate> GetBarriersAsGraph()
        {
            return this.graph;
        }
    }
}