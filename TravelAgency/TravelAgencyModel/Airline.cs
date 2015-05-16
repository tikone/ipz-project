using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Airline
    {
        public String Name { get; private set; }

        private HashSet< Ticket > m_tickets;

        public Airline( String _name )
        {
            this.Name = _name;
            m_tickets = new HashSet< Ticket >();
        }

        #region public methods

            public void AddTicket( Ticket _ticket )
            {
                m_tickets.Add( _ticket );
            }

            public Boolean CheckTicket( Ticket _ticket )
            {
                if( m_tickets.Contains( _ticket ) )
                    return _ticket.Reserved;
                else
                    throw new Exception( @"ticket not from this airline" );
            }

            public List< Ticket > GetAvailableTicket()
            {
                List< Ticket > tickets = new List< Ticket >();

                foreach( var tik in m_tickets )
                    if( !tik.Reserved )
                        tickets.Add( tik );

                return tickets;
            }

        #endregion
    }
}
