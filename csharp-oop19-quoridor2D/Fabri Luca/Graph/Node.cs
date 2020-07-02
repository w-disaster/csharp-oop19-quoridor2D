using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Graph
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