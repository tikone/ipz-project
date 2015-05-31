using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Airline
    {
        public int ID { get; private set; }

        public String Name { get; private set; }

        public HashSet< Ticket > m_tickets { get; private set; }

        public Airline( String _name )
        {
            if ( _name.Length == 0 )
                throw new ArgumentException( @"Customer full name should be filled" );

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
