using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;

namespace csharp_oop19_quoridor2D.Fabri_Luca
{
    public interface IBarrier
    {
        Coordinate Coordinate
        {
            get;
        }
        BarrierOrientation Orientation
        {
            get;
        }

        BarrierPiece Piece
        {
            get;
        }
        
    }
}