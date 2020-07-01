using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Graph
{
    public interface IGraph<X>
    {
        void Remove(Pair<X, X> edge);

        IList<Pair<X, X>> GetEdges();

        IList<Pair<X, X>> BarriersAsCoordinatesToRemove(IList<IBarrier> barriers);

        bool ContainsPath(IList<Pair<X, X>> coordinatesToRemove, X source, int destination);
    }
}