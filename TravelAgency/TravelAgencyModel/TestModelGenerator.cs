using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	public class TestModelGenerator
	{
		public TestModelGenerator( TravelAgency _travelAgency )
		{

			Customer vasia = new Customer(@"John", @"Doe");

			vasia.Registrate(
				1, @"vvv_leningrad", @"sobaka@gmail.com", 1234
			);

			DateTime dateVasia = new DateTime(2015, 5, 12);

			var rooms = generateRooms();

			Hotel hotel = new Hotel(@"AvePlazza", @"first_street", 5, rooms);

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


			vasia.addTour(tourVasia);

			_travelAgency.addCustomer(vasia);

		}

		private HashSet<Room> generateRooms()
		{
			HashSet<Room> rooms = new HashSet<Room>();

			for (int i = 1; i < 5; ++i)
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
