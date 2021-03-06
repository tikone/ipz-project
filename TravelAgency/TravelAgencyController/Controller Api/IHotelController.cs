﻿using System;
using System.Collections.Generic;

using TravelAgencyModel;
using TravelAgencyController.ViewModel;

namespace TravelAgencyController.Controller
{
    public interface IHotelController : IDisposable
    {
        Hotel[] GetAllHotels(bool _showOnlyWithAvailableTickets = true);

        ICollection< HotelView > ViewAllHotels();

        ICollection< RoomView > ViewAllRooms();

        Int32 AddNewHotelToDB(
                String _name
            ,   String _address
            ,   HotelType _type
            ,   HashSet< Room > _rooms
        );

        void RemoveHotelFromDB( Int32 _hotelID );

        List< Room > GetNotReservedRooms( Int32 _hotelID );

        void ReserveRoom( Int32 _hotelID, Room _room );

        void UpdateHotelType( Int32 _hotelID, HotelType _type );

    }
}
