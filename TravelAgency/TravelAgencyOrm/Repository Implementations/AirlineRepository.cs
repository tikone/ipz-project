using System;
using System.Linq;

using TravelAgencyModel;

namespace TravelAgencyOrm
{
    class AirlineRepository
        : BasicRepository< Airline >
        , IAirlineRepository
    {
        public AirlineRepository( TravelAgencyDbContext dbContext )
            : base( dbContext, dbContext.Airline )
        {
        }
    }
}
