using System;
using System.Linq;

using TravelAgencyModel;

namespace TravelAgencyOrm
{
    class RoomRepository
        : BasicRepository< Room >
        , IRoomRepository
    {
        public RoomRepository( TravelAgencyDbContext dbContext )
            : base( dbContext, dbContext.Rooms )
        {
        }
    }
}
