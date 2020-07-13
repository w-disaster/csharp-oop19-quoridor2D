using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;

namespace csharp_oop19_quoridor2D.D_Ambrosio_Stefano.PowerUpSpace
{
    public interface IPowerUp
    {

        Type Type
        {
            get;
        }

        Coordinate Coordinate
        {
            get;
        }

    }
}
