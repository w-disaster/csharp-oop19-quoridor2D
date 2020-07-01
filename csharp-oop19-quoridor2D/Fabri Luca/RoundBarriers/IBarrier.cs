using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;

namespace csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers
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