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
        }

        // NOTE: use bool var
        public Airline[] GetAllAirlines( bool _withHidden )
        {
            return this.airlineRepository.LoadAll().ToArray();
        }

        public Int32 AddNewAirlaneToDB( String _name )
        {
            Airline newAirline = new Airline( _name );
            this.airlineRepository.Add( newAirline );
            this.airlineRepository.Commit();

            return newAirline.ID;
        }

        public void AddTicket( Ticket _ticket, Int32 _airlineID )
        {
            Airline airline = FindObjectById( airlineRepository, _airlineID );
            airline.AddTicket( _ticket );
        }

        public List< Ticket > GetAvailableTickets( Int32 _airlineID )
        {
            Airline airline = FindObjectById(airlineRepository, _airlineID);
            return airline.GetAvailableTickets();
        }

        private IAirlineRepository airlineRepository;
    }
}
