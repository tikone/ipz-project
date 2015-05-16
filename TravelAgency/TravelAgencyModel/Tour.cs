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

            public Hotel Hotel { get; private set; }

            public List<Ticket> Tickets { get; private set; }

            public List<Room> Rooms { get; private set; }

            public Airline Airline { get; private set; }

        #endregion

        #region private fields

            private String m_description;

            private HashSet<Excursion> m_excursions;

        #endregion

        #region constructors

            public Tour(
                    DateTime _dateTime
                ,    Double _price
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

                this.Hotel = _hotel;
                this.Airline = _airline;
                this.Tickets = new List<Ticket>();

                this.Rooms = new List<Room>();
                m_excursions = new HashSet<Excursion>();

            }

        #endregion

        #region public methods

            public String ViewInfo()
            {
                return m_description;
            }
            
            public void AddExcursion( Excursion _excursion )
            {
                if( m_excursions.Contains( _excursion ))
                    throw new Exception( @"Try to add twice one excursion.");

                m_excursions.Add(_excursion);
            }

            public List< Excursion > GetExcursion()
            {
                return m_excursions.ToList();
            }

            public void ReserveTicket( Ticket _ticket )
            {
                if( _ticket == null )
                    throw new Exception( @"null ticket");
                //TODO AirLine.check( _ticket ) // check date

                if( !Airline.CheckTicket( _ticket ) )
                {
                    _ticket.Reserved = true;
                    this.Tickets.Add( _ticket );
                }
                else
                    throw new Exception( @"ticket reserved yet" );
            }

            public void ReserveRoom( Room _room )
            {
                if( _room == null )
                    throw new Exception( @"null room!" );

                if( Hotel.Rooms.Contains( _room ) )
                {
                    if( !Hotel.CheckReservedRoom( _room ) )
                    {
                        Hotel.ReserveRoom(_room);
                        this.Rooms.Add(_room);
                    }
                    else
                        throw new Exception( @"this room reserved yet!" );
                }
                else
                    throw new Exception( @"this room destroyed/not build yet!" );

            }

        #endregion

    }
}
