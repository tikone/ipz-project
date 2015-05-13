using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	class Airline
	{
		public String Name { get; private set; }

		private HashSet<Ticket> m_tickets;

		public Airline( String _name )
		{
			this.Name = _name;
			m_tickets = new HashSet<Ticket>();
		}

		public void AddTicket( Ticket _ticket )
		{
			m_tickets.Add(_ticket);
		}

		public Boolean CheckTicket( Ticket _ticket )
		{
			if (m_tickets.Contains(_ticket))	//shit
				return _ticket.Reserved;

			return false;
		}

	}
}
