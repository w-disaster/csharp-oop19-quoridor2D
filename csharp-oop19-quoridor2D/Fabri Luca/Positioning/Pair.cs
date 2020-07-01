using System.Collections.Generic;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Positioning
{
    public class Pair<X, Y>
    {
        public X First { get; }
        public Y Second { get; }
        
        public Pair(X first, Y second)
        {
            First = first;
            Second = second;
        }

        protected bool Equals(Pair<X, Y> other)
        {
            return EqualityComparer<X>.Default.Equals(First, other.First) && EqualityComparer<Y>.Default.Equals(Second, other.Second);
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
                return (EqualityComparer<X>.Default.GetHashCode(First) * 397) ^ EqualityComparer<Y>.Default.GetHashCode(Second);
            }
        }
    }
}