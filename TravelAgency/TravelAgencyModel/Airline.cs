using System;
using System.Collections.Generic;

namespace TravelAgencyModel
{
	public class Airline
	{
		public String Name { get; private set; }

		private HashSet<Ticket> m_tickets;

		public Airline( String _name )
		{
			this.Name = _name;
			m_tickets = new HashSet<Ticket>();
		}

		#region public fields

		public void AddTicket( Ticket _ticket )
		{
			m_tickets.Add( _ticket );
		}

		public Boolean CheckTicket( Ticket _ticket )
		{
			if( m_tickets.Contains( _ticket ) )
				return _ticket.Reserved;

			return false;
		}

		public List<Ticket> GetAvailableTicket()
		{
			List<Ticket> tickets = new List<Ticket>();

			foreach( var ticket in m_tickets )
			if ( !ticket.Reserved )
				tickets.Add( ticket );

			return tickets;
		}

		#endregion
	}
}
