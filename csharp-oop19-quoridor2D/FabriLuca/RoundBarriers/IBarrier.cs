using csharp_oop19_quoridor2D.FabriLuca.Positioning;

namespace csharp_oop19_quoridor2D.FabriLuca.RoundBarriers
{
    /// <summary>
    /// This interface models the single barrier object.
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