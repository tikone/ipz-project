using System;
using System.Collections.Generic;

using TravelAgencyModel;

namespace TravelAgencyController.Controller
{
    public interface IAirlineController
    {
        Airline[] GetAllAirlines( bool _withHidden = true );

        // Returns ID may be 0 lookup this code, same for hotel
        Int32 AddNewAirlineToDB( String _name );

        void RemoveAirlineFromDB( Int32 _airlineID );

        void AddTicket( Ticket _ticket, Int32 _airlineID );

        List< Ticket > GetAvailableTickets( Int32 _airlineID );
    }
}
