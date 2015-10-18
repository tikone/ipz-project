using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelAgencyModel;

namespace TravelAgencyController.Controller
{
    public interface IHotelController : IDisposable
    {

        Hotel[] GetAllHotels ( bool _withHidden = true );

        void CreateNewHotel (
                String _name
            ,   String _address
            ,   HotelType _type
            ,   HashSet< Room > _rooms
        );

        void Rename ( String _hotelName, String _newName );

        void UpdateType( String _hotelName, HotelType _type );

    }
}
