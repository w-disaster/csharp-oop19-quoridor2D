using System.Collections.Generic;
using System.ComponentModel.Design;

namespace csharp_oop19_quoridor2D.Fabri_Luca
{
    public class Pair<X, Y>
    {
        private readonly X x;
        private readonly Y y;

        public Pair(X x, Y y)
        {
            this.x = x;
            this.y = y;
        }

        public X X1 => x;

        public Y Y1 => y;

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            var other = (Pair<object,object>) obj;
            if (x == null) {
                if (other.x != null)
                    return false;
            } else if (!x.Equals(other.x))
                return false;
            if (y == null) {
                if (other.y != null)
                    return false;
            } else if (!y.Equals(other.y))
                return false;
            return true;
        }
        
    }
}