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
        Airline[] GetAllHotels(bool _withHidden = true);

        void Airline( String _name );

        void Rename( Int32 _id, String _newName);

        void AddTicket( Ticket _ticket );


    }
}
