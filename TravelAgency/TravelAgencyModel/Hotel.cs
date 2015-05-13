using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	public class Hotel
	{
		public String Name { get; set; }

		public String Address { get; set; }

		public HotelType Type { get; set; }

		public Hotel( String _name, String _address, HotelType _type, HashSet<Room> _rooms)
		{
			this.Name = _name;
			this.Address = _address;
			this.Type = _type;
			this.m_rooms = _rooms;
		}

		public Boolean CheckReservedRoom( Room _room )
		{
			if (m_rooms.Contains(_room))
				return _room.Reserved;

			return true;
		}

		private HashSet<Room> m_rooms;

	}
}
