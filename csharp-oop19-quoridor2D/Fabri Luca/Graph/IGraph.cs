using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Graph
{
    public interface IGraph<X>
    {
        /// <summary>
        /// Removes the edge
        /// </summary>
        /// <param name="edge"></param>
        void Remove(Pair<X, X> edge);
        
        /// <summary>
        /// Gets the edges
        /// </summary>
        /// <returns>the edges as a list</returns>
        IList<Pair<X, X>> GetEdges();

        /// <summary>
        /// Converts barriers to edges to remove
        /// </summary>
        /// <param name="barriers"></param>
        /// <returns>list of the edges to remove</returns>
        IList<Pair<X, X>> BarriersAsCoordinatesToRemove(IList<IBarrier> barriers);

        /// <summary>
        /// Computes BFS and checks if there's a path from node source to line destination
        /// if we remove the edges provided by the parameter.
        /// </summary>
        /// <param name="coordinatesToRemove"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns>true, if successful</returns>
        bool ContainsPath(IList<Pair<X, X>> coordinatesToRemove, X source, int destination);
    }
}