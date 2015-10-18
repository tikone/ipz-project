using System;
using System.Linq;

namespace TravelAgencyOrm
{
    public interface IRepository< T >
        where T : class
    {
        T Load( int id );

        IQueryable< T > LoadAll();

        void Add( T _element );

        void Remove( T obj );

        void Commit();
    }
}
