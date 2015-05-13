using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	class Hotel
	{
		public String Name { get; set; }

		public String Address { get; set; }

		public HotelType Type { get; set; }

		private HashSet<Room> m_rooms;

	}
}
