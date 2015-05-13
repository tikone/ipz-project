using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	class Airline
	{
		public String Name { get; set; }

		private HashSet<Ticket> m_tickets;

		public Boolean CheckTicket( Ticket _ticket )
		{
			if (m_tickets.Contains(_ticket))	//shit
				return _ticket.Reserved;

			return false;
		}

	}
}
