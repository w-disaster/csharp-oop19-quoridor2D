using csharp_oop19_quoridor2D.FabriLuca.Positioning;

namespace csharp_oop19_quoridor2D.FabriLuca.RoundBarriers
{
    /// <summary>
    /// This interface describes the single barrier entity.
    /// </summary>
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