using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;

namespace csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers
{
    public class Barrier : IBarrier
    {
        public Coordinate Coordinate { get; }
        public BarrierOrientation Orientation { get; }
        public BarrierPiece Piece { get; }

        public Barrier(Coordinate coordinate, BarrierOrientation orientation, BarrierPiece piece)
        {
            Coordinate = coordinate;
            Orientation = orientation;
            Piece = piece;
        }
    }
}