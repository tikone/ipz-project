using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	class Tour
	{
		//public Date 
		public Double Price { get; set; }

		public String Country { get; set; }

		public String Description { get; set; }

		public Int32 AmountPeople { get; set; }


		private List<Excursion> m_excursions;

		//private Hotel
		//private Airline

		private List<Ticket> m_tickets;

		public String ViewInfo()
		{
			return "";
		}

		public void AddExcursion( Excursion _excursion )
		{
			m_excursions.Add(_excursion);
		}

		public void ReserveTicket( Ticket _ticket )
		{
			//TODO
			//AirLine.check( _ticket )
			m_tickets.Add(_ticket);
		}

	}
}
