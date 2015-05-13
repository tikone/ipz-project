using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	class Ticket
	{
		public DateTime Departure { get; set; }

		public DateTime ArrivalDate { get; set; }

		public Boolean Reserved { get; set; }

		public String NumberOfAirplane { get; set; }

		public String ArrivalCountry { get; set; }

		public TicketType Type { get; set; }
	}
}
