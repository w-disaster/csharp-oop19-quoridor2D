using csharp_oop19_quoridor2D.FabriLuca.Positioning;

namespace csharp_oop19_quoridor2D.FabriLuca.Graph
{
    /// <summary>
    /// Node Class
    /// </summary>
    public class Node : INode
    {
        public Coordinate Coordinate { get; }
        public Colour Colour { get; set; }

        public Node(Coordinate coordinate, Colour colour)
        {
            Coordinate = coordinate;
            Colour = colour;
        }
    }
}