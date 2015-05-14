using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Hotel
    {

        #region public fields

        public String Name { get; set; }

        public String Address { get; set; }

        public HotelType Type { get; set; }

        public HashSet<Room> Rooms { get; set; }

        #endregion

        public Hotel( String _name, String _address, HotelType _type, HashSet<Room> _rooms)
        {
            this.Name = _name;
            this.Address = _address;
            this.Type = _type;

            this.Rooms = _rooms;
        }

        #region public methods

        public Boolean CheckReservedRoom( Room _room )
        {
            if (Rooms.Contains(_room))
                return _room.Reserved;

            return true;
        }

        public void ReserveRoom( Room _room )
        {
            if (Rooms.Contains(_room))
                _room.Reserved = true;
            else
                throw new Exception("this room reserved yet!");
        }

        #endregion

    }
}
