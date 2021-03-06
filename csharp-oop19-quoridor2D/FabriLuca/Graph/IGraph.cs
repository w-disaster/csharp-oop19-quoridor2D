using System.Collections.Generic;
using csharp_oop19_quoridor2D.FabriLuca.Positioning;

namespace csharp_oop19_quoridor2D.FabriLuca.Graph
{
    /// <summary>
    /// Graph Interface
    /// </summary>
    /// <typeparam name="X"></typeparam>
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
        /// Computes Breadth First Search (BFS) and checks if there's a path from node source to line destination
        /// if we remove the edges provided by the parameter.
        /// </summary>
        /// <param name="coordinatesToRemove"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns>true, if successful</returns>
        bool ContainsPath(IList<Pair<X, X>> coordinatesToRemove, X source, int destination);
    }
}