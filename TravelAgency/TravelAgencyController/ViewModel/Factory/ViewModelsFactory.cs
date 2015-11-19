using System;
using System.Linq;
using System.Collections.Generic;

using TravelAgencyModel;

namespace TravelAgencyController.ViewModel
{
    static class ViewModelsFactory
    {
        static internal AccountView BuildAccountView( Account _account )
        {
            return new AccountView
            {
                UserID = _account.ID,
                Login = _account.Login,
                Mail = _account.Mail,
                History = BuildViewModels( _account.History.AsQueryable(), BuildTourOrderView )
            };
        }

        static internal AirlineView BuildAirlineView( Airline _airline )
        {
            return new AirlineView
            {
                AirlineID = _airline.ID,
                Name = _airline.Name,
                Tickets = BuildViewModels( _airline.Tickets.AsQueryable(), BuildTicketView )
            };
        }

        static internal CustomerView BuildCustomerView( Customer _customer )
        {
            return new CustomerView
            {
                CustomerID = _customer.ID,
                Name = _customer.Name,
                Surname = _customer.Surname,
                Account = _customer.Account
            };
        }

        static internal ExcursionView BuildExcursionView( Excursion _excursion )
        {
            return new ExcursionView
            {
                ExcursionID = _excursion.ExcursionID,
                Name = _excursion.Name,
                Price = _excursion.Price,
                DateTime = _excursion.Date_Time,
                Guides = BuildViewModels( _excursion.Guides.AsQueryable(), BuildGuideView )
            };
        }

        static internal GuidesView BuildGuideView( Guide _guide )
        {
            return new GuidesView
            {
                Name = _guide.Name,
                Available = _guide.Available,
                Phone = _guide.Phone,
                Languages = _guide.Languages,
            };
        }

        static internal HotelView BuildHotelView( Hotel _hotel )
        {
            return new HotelView
            {
                HotelId = _hotel.ID,
                Name = _hotel.Name,
                Address = _hotel.Address,
                HotelType = _hotel.Type.ToString(),
                Rooms = BuildViewModels( _hotel.Rooms.AsQueryable(), BuildRoomView )
            };
        }

        static internal RoomView BuildRoomView( Room _room )
        {
            return new RoomView
            {
                Number = _room.Number,
                BedNumber = _room.BedNumber,
                Reserved = _room.Reserved,
                TypeOfBeds = _room.TypeOfBeds.ToString(),
                TypeOfRoom = _room.TypeOfRoom.ToString()
            };
        }

        static internal TicketView BuildTicketView( Ticket _ticket )
        {
            return new TicketView
            {
                TicketID = _ticket.TicketID,
                Departure = _ticket.Departure.ToString(),
                ArrivalDate = _ticket.ArrivalDate.ToString(),
                Reserved = _ticket.Reserved,
                NumberOfAirplane = _ticket.NumberOfAirplane,
                ArrivalCountry = _ticket.ArrivalCountry,
                Type = _ticket.Type.ToString()
            };
        }

        static internal TourOrderView BuildTourOrderView( TourOrder _tourOrder )
        {
            return new TourOrderView
            {
                TourOrderID = _tourOrder.TourOrderID,
                DateTime = _tourOrder.Date_Time.ToString(),
                Price = _tourOrder.Price,
                Tickets = BuildViewModels( _tourOrder.Tickets.AsQueryable(), BuildTicketView ),
                Rooms = BuildViewModels( _tourOrder.Rooms.AsQueryable(), BuildRoomView ),
                Excursions = BuildViewModels( _tourOrder.m_excursions.AsQueryable(), BuildExcursionView )
            };
        }

        static internal TourView BuildTourView( Tour _tour )
        {
            return new TourView
            {
                TourID = _tour.TourID,
                Country = _tour.Country,
                Type = _tour.Type.ToString(),
                Description = _tour.Description,
            };
        }

        static internal ICollection< _TView > BuildViewModels< _TView, _TEntity >(
                IQueryable< _TEntity > query
            ,   Func< _TEntity, _TView> converter
        )
        {
            var results = new List< _TView >();
            foreach ( _TEntity entity in query )
                results.Add( converter( entity ) );
            return results;
        }
    }
}
