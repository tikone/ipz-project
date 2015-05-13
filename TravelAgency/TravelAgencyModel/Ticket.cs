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

		public Ticket (
				DateTime _departure
			,	DateTime _arrivalDate
			,	String _numberOfAirplane
			,	String _arrivalContry
			,	TicketType _type
		)
		{
			this.Departure = _departure;
			this.ArrivalDate = _arrivalDate;
			this.NumberOfAirplane = _numberOfAirplane;
			this.ArrivalCountry = _arrivalContry;
			this.Type = _type;
		}
	}
}
