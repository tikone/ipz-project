using System;
using System.Linq;

using TravelAgencyModel;

namespace TravelAgencyOrm
{
    class TourOrderRepository
        : BasicRepository<TourOrder>
        , ITourOrderRepository
    {
        public TourOrderRepository(TravelAgencyDbContext dbContext)
            : base(dbContext, dbContext.TourOrder)
        {
        }
    }
}
