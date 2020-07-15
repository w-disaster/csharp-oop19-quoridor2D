using csharp_oop19_quoridor2D.FabriLuca.Positioning;

namespace csharp_oop19_quoridor2D.FabriLuca.Graph
{
    /// <summary>
    /// INode interface to compute Breadth First Search (BFS)
    /// </summary>
    public interface INode
    {
        Coordinate Coordinate
        {
            get;
        }

        Colour Colour
        {
            get;
            set;
        }
        
    }
}