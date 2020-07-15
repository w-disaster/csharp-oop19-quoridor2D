using System;
using csharp_oop19_quoridor2D.FabriLuca;
using csharp_oop19_quoridor2D.FabriLuca.Positioning;
using csharp_oop19_quoridor2D.FabriLuca.RoundBarriers;

namespace csharp_oop19_quoridor2D.CastellaniThomas
{
    public interface IBarrierPlacer
    {
        void PlaceBarrier(Coordinate position, BarrierOrientation orientation);

        bool CheckPlacement(Coordinate position, BarrierOrientation orientation);
    }
}
