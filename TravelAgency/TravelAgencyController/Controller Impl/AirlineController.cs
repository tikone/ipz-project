using System;
using System.Linq;
using System.Collections.Generic;

using TravelAgencyOrm;
using TravelAgencyModel;

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

        public Airline[] GetAllAirlines( bool _showOnlyWithAvailableTickets )
        {
            var tickets = this.airlineRepository.LoadAll();
            return
                    _showOnlyWithAvailableTickets
                ?   WithAvailableTicketsOnly( tickets ).ToArray()
                :   tickets.ToArray();
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
