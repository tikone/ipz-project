using System;
using System.Collections.Generic;

using TravelAgencyModel;
using TravelAgencyController.ViewModel;

namespace TravelAgencyController.Controller
{
    public interface IAirlineController : IDisposable
    {
        Airline[] GetAllAirlines( bool _withHidden = true );

        ICollection< AirlineView > ViewAllAirlines();

        ICollection< TicketView > ViewAllTickets();

        Int32 AddNewAirlineToDB( String _name );

        void RemoveAirlineFromDB( Int32 _airlineID );

        Int32 CreateNewTicket(
                DateTime _departure
            ,   DateTime _arrivalDate
            ,   String _numberOfAirplane
            ,   String _arrivalContry
            ,   TicketType _type );

        void AddTicket( Int32 _ticketID, Int32 _airlineID );

        void AddTicket( Ticket _ticket, Int32 _airlineID );

        List< Ticket > GetAvailableTickets( Int32 _airlineID );
    }
}
