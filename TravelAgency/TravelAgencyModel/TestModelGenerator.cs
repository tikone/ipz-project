using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	class TestModelGenerator
	{
		private TravelAgency m_travelAgency;

		public TestModelGenerator( TravelAgency _travelAgency )
		{

			Customer vasia = new Customer(@"vasia", @"petrov");

			DateTime dateVasia = new DateTime(2015, 5, 12);

			var rooms = generateRooms();

			Hotel hotel = new Hotel(@"azaza", @"best_street_eu", HotelType.FiveStar, rooms);

			var airline = generateAirline();

			Tour tourVasia =
				new Tour(dateVasia, 1000, @"Ua", @"niceTour", 2, TourType.Beer, hotel, airline);

			tourVasia.ReserveRoom( rooms.ElementAt( 0 ));

			tourVasia.ReserveTicket(airline.GetAvailableTicket()[0]);

			tourVasia.AddExcursion(
				new Excursion(
						@"excursion"
					, 223
					, new DateTime(2015, 7, 12)
				)
			);


			m_travelAgency

		}

		private HashSet<Room> generateRooms()
		{
			HashSet<Room> rooms = new HashSet<Room>();

			for (int i = 0; i < 5; ++i)
				rooms.Add(new Room(i, BedType.Single));

			return rooms;
		}

		private Airline generateAirline()
		{
			Airline airline = new Airline(@"ukrop_line");

			Ticket tick1 =
				new Ticket(
						new DateTime(2015, 5, 12)
					,	new DateTime(2015, 5, 17)
					,	"mk322"
					,	"ua"
					,	TicketType.BusinessClass
				);

			Ticket tick2 =
				new Ticket(
						new DateTime(2015, 6, 12)
					, new DateTime(2015, 6, 17)
					, "mk322"
					, "ua"
					, TicketType.BusinessClass
				);

			airline.AddTicket(tick1);
			airline.AddTicket(tick2);

			return airline;
		}

	}
}
