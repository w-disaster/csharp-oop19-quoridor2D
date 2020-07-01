using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Graph
{
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