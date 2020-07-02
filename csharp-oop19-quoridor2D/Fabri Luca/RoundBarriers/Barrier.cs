using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;

namespace csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers
{
    /// <summary>
    /// The BarrierImpl class
    /// </summary>
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

        protected bool Equals(Barrier other)
        {
            return Equals(Coordinate, other.Coordinate) && Orientation == other.Orientation && Piece == other.Piece;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Barrier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Coordinate != null ? Coordinate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Orientation;
                hashCode = (hashCode * 397) ^ (int) Piece;
                return hashCode;
            }
        }
    }
}