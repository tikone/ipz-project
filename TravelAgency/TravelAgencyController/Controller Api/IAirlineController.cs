using System;
using System.Linq;
using System.Collections.Generic;

using TravelAgencyModel;

namespace TravelAgencyController.Controller
{
    public interface IAirlineController
    {
        Airline[] GetAllAirlines( bool _withHidden = true );

        Int32 AddNewAirlaneToDB( String _name );

        void AddTicket( Ticket _ticket, Int32 _airlineID );

        List< Ticket > GetAvailableTickets( Int32 _airlineID );
    }
}
