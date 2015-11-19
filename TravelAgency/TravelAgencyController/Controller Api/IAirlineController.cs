using System;
using System.Collections.Generic;

using TravelAgencyModel;

namespace TravelAgencyController.Controller
{
    public interface IAirlineController
    {
        Airline[] GetAllAirlines( bool _withHidden = true );

        Int32 AddNewAirlineToDB( String _name );

        void RemoveAirlineFromDB( Int32 _airlineID );

        void AddTicket( Ticket _ticket, Int32 _airlineID );

        List< Ticket > GetAvailableTickets( Int32 _airlineID );
    }
}
