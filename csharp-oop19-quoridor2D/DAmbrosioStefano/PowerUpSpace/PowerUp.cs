using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;
using System;

namespace csharp_oop19_quoridor2D.D_Ambrosio_Stefano.PowerUpSpace
{
    public class PowerUp : IPowerUp
    {
        private readonly Random random;
        public Type Type { get; }
        public Coordinate Coordinate { get; }

        public PowerUp(Type type)
        {
            this.random = new Random();
            this.Type = type;
            this.Coordinate = new Coordinate(2 + random.Next(RoundBarriers.BoardDimension - 4),
                2 + random.Next(RoundBarriers.BoardDimension - 4));
        }

    }
}
