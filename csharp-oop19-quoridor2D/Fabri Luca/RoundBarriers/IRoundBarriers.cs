using System.Collections.Generic;
using csharp_oop19_quoridor2D.Fabri_Luca.Graph;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;

namespace csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers
{
    public interface IRoundBarriers
    {
        /// <summary>
        /// Adds a barrier
        /// </summary>
        /// <param name="barrier"></param>
        void Add(IBarrier barrier);

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="barrier"></param>
        /// <returns></returns> true if there is a IBarrier barrier
        bool Contains(IBarrier barrier);

        /// <summary>
        /// Get barriers as a list IList
        /// </summary>
        /// <returns></returns> the list
        IList<IBarrier> GetBarriersAsList();
        
        /// <summary>
        /// Get barriers as a graph IGraph
        /// </summary>
        /// <returns></returns>
        IGraph<Coordinate> GetBarriersAsGraph();
    }
}