using System;
using csharp_oop19_quoridor2D.Fabri_Luca;

namespace csharp_oop19_quoridor2D.CastellaniThomas
{
    public interface IBarrierPlacer
    {
        void PlaceBarrier(Coordinate position, BarrierOrientation orientation);
    }
}
