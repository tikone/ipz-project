using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModel
{
    public class TourOrder
    {
        public event EventHandler SendingTour;

        #region public fields

            public Int32 TourOrderID { get; set; }

            public DateTime Date_Time { get; set; }

            public Double Price { get; set; }

            public virtual List<Ticket> Tickets { get; private set; }

            public virtual HashSet<Room> Rooms { get; private set; }

            public virtual HashSet<Excursion> m_excursions { get; private set; }

            public Int32 AmountPeople
            {
                get { return m_amountPeople; }
                set
                {
                    if (value < 1)
                        throw new ArgumentException( @"Positive number of people expected" );
                    m_amountPeople = value;
                }
            }

            public virtual Tour Tour { get; private set; }

            public virtual Customer Customer { get; private set; }

        #endregion

        #region private fields

            private Int32 m_amountPeople;

        #endregion

        #region constructors

            public TourOrder(
                    Tour _tour
                ,   DateTime _dateTime
                ,   Double _price
                ,   Customer _customer
                ,   Int32 _amountPeople = 1
            )
            {
                if( _tour == null )
                    throw new ArgumentException( @" tour nullptr" );

                this.Tour = _tour;
                this.Date_Time = _dateTime;
                this.Price = _price;
                this.Customer = _customer;

                this.AmountPeople = _amountPeople;

                this.Tickets = new List<Ticket>();

                this.Rooms = new HashSet<Room>();
                this.m_excursions = new HashSet<Excursion>();

            }

            protected TourOrder() {}

        #endregion

        #region public methods

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

                if ( _ticket.ArrivalCountry != Tour.Country )
                    throw new ArgumentException( "Country in ticket must be equal country in tour" );
                
                //if( !Airline.CheckTicket( _ticket ) )
                //{
                //    _ticket.Reserved = true;
                //    this.Tickets.Add( _ticket );
                //}
                //else
                //    throw new Exception( @"ticket reserved yet" );
            }

            public void SendTourForOperator()
            {
                if( SendingTour != null )
                    SendingTour( this, EventArgs.Empty );
            }

        #endregion

    }
}
