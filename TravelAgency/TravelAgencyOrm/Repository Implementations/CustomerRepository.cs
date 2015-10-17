using System;
using System.Linq;

using TravelAgencyModel;

namespace TravelAgencyOrm
{
    class CustomerRepository
        : BasicRepository< Customer >
        , ICustomerRepository
    {
        public CustomerRepository( TravelAgencyDbContext dbContext )
            :   base( dbContext, dbContext.Customers )
        {
        }
    }
}
