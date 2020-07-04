using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop19_quoridor2D.D_Ambrosio_Stefano
{
    public class PowerUp : IPowerUp
    {
        private readonly Random random;
        private Type Type { get; }
        private Coordinate Coordinate { get; }

        public PowerUp(Type type, int boardDimension)
        {
            this.random = new Random();
            this.Type = type;
            this.Coordinate = new Coordinate(2 + random.Next(boardDimension - 4), 2 + random.Next(boardDimension - 4));
        }

    }
}
