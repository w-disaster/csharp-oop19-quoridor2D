using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Graph
{
    public interface INode
    {
        Coordinate GetCoordinate();
        
        Colour GetColour();

        void SetColour(Colour colour);
    }
}