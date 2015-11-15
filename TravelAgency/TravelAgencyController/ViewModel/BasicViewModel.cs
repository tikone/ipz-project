using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgencyController.ViewModel
{
    public abstract class BasicViewModel< ConcreteView >
        where ConcreteView : BasicViewModel< ConcreteView >
    {
        public override bool Equals( object other )
        {
            return Equals( other as ConcreteView );
        }

        public bool Equals( ConcreteView other )
        {
            if(other == null )
                return false;

            var sequence1 = GetAttributesToIncludeInEqualityCheck();
            var sequence2 = other.GetAttributesToIncludeInEqualityCheck();
            return sequence1.SequenceEqual( sequence2 );
        }

        public static bool operator == (
                BasicViewModel< ConcreteView > left
            ,   BasicViewModel< ConcreteView > right )
        {
            return Equals( left, right );
        }

        public static bool operator != (
                BasicViewModel< ConcreteView > left
            ,   BasicViewModel< ConcreteView > right )
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            foreach( var obj in this.GetAttributesToIncludeInEqualityCheck() )
                hash = hash << 3 + ( obj == null ? 0 : obj.GetHashCode() );
            return hash;
        }

        protected abstract IEnumerable< object > GetAttributesToIncludeInEqualityCheck();
    }
}