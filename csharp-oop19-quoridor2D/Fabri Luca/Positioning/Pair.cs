using System.Collections.Generic;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Positioning
{
    public class Pair<X, Y>
    {
        private readonly X _first; 
        private readonly Y _second;

        public Pair(X first, Y second)
        {
            this._first = first;
            this._second = second;
        }

        public X First => _first;

        public Y Second => _second;

        protected bool Equals(Pair<X, Y> other)
        {
            return EqualityComparer<X>.Default.Equals(_first, other._first) && EqualityComparer<Y>.Default.Equals(_second, other._second);
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
                return (EqualityComparer<X>.Default.GetHashCode(_first) * 397) ^ EqualityComparer<Y>.Default.GetHashCode(_second);
            }
        }
    }
}