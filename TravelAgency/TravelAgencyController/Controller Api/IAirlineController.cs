using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelAgencyModel;

namespace TravelAgencyController.Controller
{
    public interface IAirlineController
    {
        Airline[] GetAllAirlines( bool _withHidden = true );

        void AddNewAirlaneToDB( String _name );

        void Rename( Int32 _airlineID, String _newName );

        void AddTicket( Ticket _ticket );

        List< Ticket > GetAvailableTickets( Int32 _airlineID );
    }
}
