using System;
using System.Linq;
using System.Collections.Generic;

using TravelAgencyOrm;
using TravelAgencyModel;

namespace TravelAgencyController.Controller
{
    class HotelController
        : BasicController
        , IHotelController
    {
        public HotelController()
        {
            this.hotelRepository = RepositoryFactory.CreateHotelRepository( GetDBContext() );
            this.roomRepository = RepositoryFactory.CreateRoomRepository( GetDBContext() );
        }

        public Hotel[] GetAllHotels( bool _whichHasFreeRooms )
        {
            var hotels = this.hotelRepository.LoadAll();
            return
                    _whichHasFreeRooms
                ?   WithFreeFreeRooms( hotels ).ToArray()
                :   hotels.ToArray();
        }

        public Int32 AddNewHotelToDB(
                String _name
            ,   String _address
            ,   HotelType _type
            ,   HashSet< Room > _rooms
        )
        {
            Hotel newHotel = new Hotel( _name, _address, _type, _rooms );
            this.hotelRepository.Add( newHotel );
            this.hotelRepository.Commit();

            foreach (var room in _rooms)
                this.roomRepository.Add( room );
            this.roomRepository.Commit();

            return newHotel.ID;
        }

        public void RemoveHotelFromDB( Int32 _hotelID )
        {
            Hotel hotel = FindObjectById( this.hotelRepository, _hotelID );
            this.hotelRepository.Remove( hotel );
            this.hotelRepository.Commit();
        }

        public List< Room > GetNotReservedRooms( Int32 _hotelID )
        {
            Hotel hotel = FindObjectById( this.hotelRepository, _hotelID );
            return hotel.NotReservedRoom();
        }

        public void ReserveRoom( Int32 _hotelID, Room _room )
        {
            Hotel hotel = FindObjectById( this.hotelRepository, _hotelID );
            hotel.ReserveRoom( _room );
            this.roomRepository.Commit();
            this.hotelRepository.Commit();
        }

        public void UpdateHotelType( Int32 _hotelID, HotelType _type )
        {
            Hotel hotel = FindObjectById( this.hotelRepository, _hotelID );
            hotel.Type = _type;
            this.hotelRepository.Commit();
        }

        private IQueryable< Hotel > WithFreeFreeRooms( IQueryable< Hotel > _hotels )
        {
            return _hotels.Where( hotel => hotel.NotReservedRoom().Count() != 0 );
        }

        private IHotelRepository hotelRepository;
        private IRoomRepository roomRepository;
    }
}
