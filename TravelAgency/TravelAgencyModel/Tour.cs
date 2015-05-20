using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Tour
    {

        public event EventHandler SendingTour;

        #region public fields

            public DateTime Date_Time { get; set; }

            public Double Price { get; set; }

            public String Country { get; set; }

            public TourType Type { get; set; }

            public Hotel Hotel { get; private set; }

            public List<Ticket> Tickets { get; private set; }

            public List<Room> Rooms { get; private set; }

            public Airline Airline { get; private set; }

            public Int32 AmountPeople
            {
                get
                {
                    return m_amountPeople;
                }
                set
                {
                    if (value < 1)
                        throw new ArgumentException( @"Positive number of people expected" );
                    m_amountPeople = value;
                }
            }

        #endregion

        #region private fields

            private String m_description;

            private Int32 m_amountPeople;

            private HashSet<Excursion> m_excursions;

        #endregion

        #region constructors

            public Tour(
                    DateTime _dateTime
                ,    Double _price
                ,    String _country
                ,    String _description
                ,    TourType _type
                ,    Hotel _hotel
                ,    Airline _airline
                ,   Int32 _amountPeople = 1
            )
            {
                this.Date_Time = _dateTime;
                this.Price = _price;

                if (_country.Length == 0)
                    throw new ArgumentException( "Country should be filled" );

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
                    throw new ArgumentException( @"Try to add twice one excursion.");
                
                if ( Date_Time > _excursion.Date_Time )
                    throw new ArgumentException( @"Date in tour must be before date of excursions." );

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

                if ( _ticket.ArrivalCountry != Country )
                    throw new ArgumentException( "Country in ticket must be equal country in tour" );

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

            public void SendTourForOperator()
            {
                if( SendingTour != null )
                    SendingTour( this, EventArgs.Empty );
            }

        #endregion

    }
}
