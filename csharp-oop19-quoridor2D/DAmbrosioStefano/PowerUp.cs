using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop19_quoridor2D.DAmbrosioStefano
{
    public class PowerUp : IPowerUp
    {
        private static readonly Random random = new Random();
        public Type Type { get; }
        public Coordinate Coordinate { get; }

        public PowerUp(Type type)
        {
            this.Type = type;
            this.Coordinate = new Coordinate(2 + random.Next(RoundBarriers.BoardDimension - 4),
            2 + random.Next(RoundBarriers.BoardDimension - 4));
        }

    }
}
