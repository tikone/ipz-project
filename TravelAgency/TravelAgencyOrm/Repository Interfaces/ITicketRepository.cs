using System;
using System.Linq;

using TravelAgencyModel;

namespace TravelAgencyOrm
{
    public interface ITicketRepository
        : IRepository< Ticket >
    {
    }
}
