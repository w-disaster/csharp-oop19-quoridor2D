using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Graph
{
    public class Node : INode
    {
        private Coordinate _coordinate;
        private Colour _colour;

        public Node(Coordinate coordinate, Colour colour)
        {
            _coordinate = coordinate;
            _colour = colour;
        }

        public Coordinate GetCoordinate()
        {
            return this._coordinate;
        }

        public Colour GetColour()
        {
            return this._colour;
        }

        public void SetColour(Colour colour)
        {
            this._colour = colour;
        }
    }
}