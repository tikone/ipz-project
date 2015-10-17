using System;
using System.Linq;

using TravelAgencyModel;

namespace TravelAgencyOrm
{
    class HotelRepository
        : BasicRepository< Hotel >
        , IHotelRepository
    {
        public HotelRepository( TravelAgencyDbContext dbContext )
            : base( dbContext, dbContext.Hotels )
        {
        }
    }
}
