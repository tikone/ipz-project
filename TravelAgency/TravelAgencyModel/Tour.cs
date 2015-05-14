using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Tour
    {

        #region public fields

            public DateTime Date_Time { get; set; }

            public Double Price { get; set; }

            public String Country { get; set; }

            public Int32 AmountPeople { get; set; }

            public TourType Type { get; set; }

            public Hotel m_hotel {get; set;}

            public List<Ticket> Tickets { get; private set; }

            public List<Room> Rooms { get; private set; }

        #endregion

        #region private fields

            private String m_description;

            private List<Excursion> m_excursions;

            private Airline m_airline;

        #endregion

        #region constructors

            public Tour(
                    DateTime _dateTime
                ,    Double    _price
                ,    String _country
                ,    String _description
                ,    Int32 _amountPeople
                ,    TourType _type
                ,    Hotel _hotel
                ,    Airline _airline
            )
            {
                this.Date_Time = _dateTime;
                this.Price = _price;
                this.Country = _country;
                this.m_description = _description;
                this.AmountPeople = _amountPeople;
                this.Type = _type;

                this.m_hotel = _hotel;
                this.m_airline = _airline;
                this.Tickets = new List<Ticket>();

                this.Rooms = new List<Room>();
                m_excursions = new List<Excursion>();

            }

        #endregion

        #region public methods

            public String ViewInfo()
            {
                return m_description;
            }

            public void AddExcursion( Excursion _excursion )
            {
                //TODO check date
                m_excursions.Add(_excursion);
            }

            public void ReserveTicket( Ticket _ticket )
            {
                //TODO AirLine.check( _ticket ) // check date
                this.Tickets.Add(_ticket);
            }

            public void ReserveRoom( Room _room )
            {
                //TODO Room.check()
                if (!m_hotel.CheckReservedRoom(_room))
                {
                    m_hotel.ReserveRoom(_room);
                    this.Rooms.Add(_room);
                }

            }

        #endregion

    }
}
