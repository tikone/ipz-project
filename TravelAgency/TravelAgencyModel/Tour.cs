using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	public class Tour
	{

#region public fields

		public DateTime Date_Time { get; set; }

		public Double Price { get; set; }

		public String Country { get; set; }

		public Int32 AmountPeople { get; set; }

		public TourType Type { get; set; }

#endregion

#region private fields

		private String m_description;

		private List<Excursion> m_excursions;

		private List<Ticket> m_tickets;

		private List<Room> m_rooms;

		private Hotel m_hotel;
		private Airline m_airline;

		//todo
		//private Photo

#endregion

#region constructors

		Tour(
				DateTime _dateTime
			,	Double	_price
			,	String _country
			,	String _description
			,	Int32 _amountPeople
			,	TourType _type
		)
		{
			this.Date_Time = _dateTime;
			this.Price = _price;
			this.Country = _country;
			this.m_description = _description;
			this.AmountPeople = _amountPeople;
			this.Type = _type;

			m_excursions = new List<Excursion>();
			m_tickets = new List<Ticket>();
			m_rooms = new List<Room>();

		}

#endregion

#region public methods

		public String ViewInfo()
		{
			return m_description;
		}

		public void AddExcursion( Excursion _excursion )
		{
			//TODO check date
			m_excursions.Add(_excursion);
		}

		public void ReserveTicket( Ticket _ticket )
		{
			//TODO AirLine.check( _ticket ) // check date
			m_tickets.Add(_ticket);
		}

		public void ReserveRoom( Room _room )
		{
			//TODO Room.check()
			m_rooms.Add(_room);
		}

#endregion

	}
}
