using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Airline
    {
        public Int32 ID { get; set; }

        public String Name { get; private set; }

        public virtual HashSet<Ticket> Tickets { get; private set; }

        public Airline( String _name )
        {
            if ( _name.Length == 0 )
                throw new ArgumentException( @"Customer full name should be filled" );

            this.Name = _name;
            Tickets = new HashSet< Ticket >();
        }

        protected Airline() { }

        #region public methods

            public void AddTicket( Ticket _ticket )
            {
                Tickets.Add( _ticket );
            }

            public Boolean CheckTicket( Ticket _ticket )
            {
                if( Tickets.Contains( _ticket ) )
                    return _ticket.Reserved;
                else
                    throw new Exception( @"ticket not from this airline" );
            }

            public List< Ticket > GetAvailableTickets()
            {
                List< Ticket > tickets = new List< Ticket >();

                foreach( var tik in Tickets )
                    if( !tik.Reserved )
                        tickets.Add( tik );

                return tickets;
            }

        #endregion
    }
}
