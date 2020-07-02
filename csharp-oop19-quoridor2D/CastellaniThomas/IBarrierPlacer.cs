using System;
using csharp_oop19_quoridor2D.Fabri_Luca;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;

namespace csharp_oop19_quoridor2D.CastellaniThomas
{
    public interface IBarrierPlacer
    {
        void PlaceBarrier(Coordinate position, BarrierOrientation orientation);

        bool CheckPlacement(Coordinate position, BarrierOrientation orientation);
    }
}
