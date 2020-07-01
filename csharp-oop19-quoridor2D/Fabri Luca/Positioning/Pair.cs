using System.Collections.Generic;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Positioning
{
    public class Pair<X, Y>
    {
        private readonly X first; 
        private readonly Y second;

        public Pair(X first, Y second)
        {
            this.first = first;
            this.second = second;
        }

        public X First => first;

        public Y Second => second;

        protected bool Equals(Pair<X, Y> other)
        {
            return EqualityComparer<X>.Default.Equals(first, other.first) && EqualityComparer<Y>.Default.Equals(second, other.second);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Pair<X, Y>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<X>.Default.GetHashCode(first) * 397) ^ EqualityComparer<Y>.Default.GetHashCode(second);
            }
        }
    }
}