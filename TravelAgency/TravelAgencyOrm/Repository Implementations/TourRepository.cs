using System;
using System.Linq;

using TravelAgencyModel;

namespace TravelAgencyOrm
{
    class TourRepository
        : BasicRepository< Tour >
        , ITourRepository
    {
        public TourRepository( TravelAgencyDbContext dbContext )
            : base( dbContext, dbContext.Tours )
        {
        }
    }
}
