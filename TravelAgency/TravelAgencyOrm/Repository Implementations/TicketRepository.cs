using System;
using System.Linq;

using TravelAgencyModel;

namespace TravelAgencyOrm
{
    class TicketRepository
        : BasicRepository< Ticket>
        , ITicketRepository
    {
        public TicketRepository( TravelAgencyDbContext dbContext )
            : base( dbContext, dbContext.Tickets )
        {
        }
    }
}
