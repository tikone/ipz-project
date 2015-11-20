using System;
using System.Linq;
using System.Collections.Generic;

using TravelAgencyOrm;
using TravelAgencyModel;
using TravelAgencyController.ViewModel;

namespace TravelAgencyController.Controller
{
    class AirlineController
        : BasicController
        , IAirlineController
    {
        public AirlineController()
        {
            this.airlineRepository = RepositoryFactory.CreateAirlineRepository( GetDBContext() );
            this.ticketRepository = RepositoryFactory.CreateTicketRepository( GetDBContext() );
        }

        public ICollection< AirlineView > ViewAllAirlines()
        {
            var query = airlineRepository.LoadAll();
            return ViewModelsFactory.BuildViewModels( query, ViewModelsFactory.BuildAirlineView );
        }

        public Airline[] GetAllAirlines( bool _showOnlyWithAvailableTickets )
        {
            var tickets = this.airlineRepository.LoadAll();
            return
                    _showOnlyWithAvailableTickets
                ?   WithAvailableTicketsOnly( tickets ).ToArray()
                :   tickets.ToArray();
        }

        public ICollection< TicketView > ViewAllTickets()
        {
            var query = ticketRepository.LoadAll();
            return ViewModelsFactory.BuildViewModels( query, ViewModelsFactory.BuildTicketView );
        }

        public Int32 AddNewAirlineToDB( String _name )
        {
            Airline newAirline = new Airline( _name );
            this.airlineRepository.Add( newAirline );
            this.airlineRepository.Commit();

            return newAirline.ID;
        }

        public void RemoveAirlineFromDB( Int32 _airlineID )
        {
            Airline airline = FindObjectById( this.airlineRepository, _airlineID );
            this.airlineRepository.Remove( airline );
            this.airlineRepository.Commit();
        }

        public Int32 CreateNewTicket(
                DateTime _departure
            ,   DateTime _arrivalDate
            ,   String _numberOfAirplane
            ,   String _arrivalContry
            ,   TicketType _type )
        {
            Ticket ticket = new Ticket( _departure, _arrivalDate, _numberOfAirplane, _arrivalContry, _type );
            this.ticketRepository.Add( ticket );
            this.ticketRepository.Commit();

            return ticket.TicketID;
        }

        public void AddTicket( Int32 _ticketID, Int32 _airlineID )
        {
            Airline airline = FindObjectById( this.airlineRepository, _airlineID );
            Ticket ticket = FindObjectById( this.ticketRepository, _ticketID );
            airline.AddTicket( ticket );
            airlineRepository.Commit();
        }

        public void AddTicket( Ticket _ticket, Int32 _airlineID )
        {
            Airline airline = FindObjectById( this.airlineRepository, _airlineID );
            airline.AddTicket( _ticket );
            airlineRepository.Commit();

            ticketRepository.Add (_ticket );
            ticketRepository.Commit();
        }

        public List< Ticket > GetAvailableTickets( Int32 _airlineID )
        {
            Airline airline = FindObjectById( this.airlineRepository, _airlineID );
            return airline.GetAvailableTickets();
        }

        private IQueryable< Airline > WithAvailableTicketsOnly( IQueryable< Airline > _airlines )
        {
            return _airlines.Where( a => a.GetAvailableTickets().Count() != 0 );
        }

        private IAirlineRepository airlineRepository;
        private ITicketRepository ticketRepository;
    }
}
