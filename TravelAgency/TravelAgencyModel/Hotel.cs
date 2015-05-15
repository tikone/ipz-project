using System;
using System.Collections.Generic;

namespace TravelAgencyModel
{
	public class Hotel
	{

		#region public fields

		public String Name { get; set; }

		public String Address { get; set; }

		public int Type {
			get { return type; }
			set{ 
				if( value < 1 || value > 5 )
					throw new ArgumentException( "Invalid parametr for hotel type. Must be in range[1;5]" );
				else
					type = value;
				}
			}

		public HashSet<Room> Rooms { get; set; }

		#endregion

		public Hotel( String _name, String _address, int _type, HashSet<Room> _rooms )
		{
			this.Name = _name;
			this.Address = _address;
			this.Type = _type;

			this.Rooms = _rooms;
		}

		#region public methods

		public Boolean CheckReservedRoom( Room _room )
		{
			if( Rooms.Contains(_room) )
				return _room.Reserved;

			return true;
		}

		public void ReserveRoom( Room _room )
		{
			if( Rooms.Contains(_room) )
				_room.Reserved = true;
			else
				throw new Exception("this room reserved yet!");
		}

		#endregion

		#region private fields

		private int type;

		#endregion

	}
}
