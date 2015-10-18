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

        Hotel[] GetAllHotels( bool _withHidden = true );

        void AddNewHotelToDB(
                String _name
            ,   String _address
            ,   HotelType _type
            ,   HashSet< Room > _rooms
        );

        void RemoveHotelFromDB( Int32 _hotelID );

        List< Room > GetNotReservedRooms();

        void ReserveRoom( Int32 _hotelID, Room _room );

        void Rename( Int32 _hotelID, String _newName );

        void UpdateHotelType( Int32 _hotelID, HotelType _type );

    }
}
