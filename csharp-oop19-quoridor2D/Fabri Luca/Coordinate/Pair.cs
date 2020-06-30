using System.Collections.Generic;
using System.ComponentModel.Design;

namespace csharp_oop19_quoridor2D.Fabri_Luca
{
    public class Pair<T, Z>
    {
        private T x { get; }
        private Z y { get; }

        public Pair(T x, Z y)
        {
            this.x = x;
            this.y = y;
        }

        protected bool Equals(Pair<T, Z> other)
        {
            return EqualityComparer<T>.Default.Equals(x, other.x) && EqualityComparer<Z>.Default.Equals(y, other.y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Pair<T, Z>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(x) * 397) ^ EqualityComparer<Z>.Default.GetHashCode(y);
            }
        }
    }
}