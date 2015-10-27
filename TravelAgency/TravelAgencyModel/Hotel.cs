using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Hotel
    {

        #region public fields

            public Int32 ID { get; set; }

            public String Name { get; private set; }

            public String Address { get; private set; }

            public HotelType Type { get; set; }

            public virtual HashSet<Room> Rooms { get; set; }

        #endregion

        #region constructor

            public Hotel(
                    String _name
                ,   String _address
                ,   HotelType _type
                ,   HashSet< Room > _rooms
            )
            {
                this.Name = _name;
                this.Address = _address;
                this.Type = _type;

                this.Rooms = _rooms;
            }

            protected Hotel() { }

        #endregion

        #region public methods

            public Boolean CheckReservedRoom( Room _room )
            {
                if( Rooms.Contains( _room ) )
                    return _room.Reserved;

                return true;
            }

            public List< Room > NotReservedRoom()
            {
                var rooms = new List< Room >();

                foreach( var i in Rooms )
                    if( !i.Reserved )
                        rooms.Add( i );

                return rooms;
            }

            public void ReserveRoom( Room _room )
            {
                if( Rooms.Contains( _room ) )
                    _room.Reserved = true;
                else
                    throw new Exception( "this room reserved yet!" );
            }

        #endregion

        #region override methods

            public override bool Equals( Object obj )
            {
                if( obj is Hotel )
                {
                    var that = obj as Hotel;
                    return this.Address == that.Address && this.Name == that.Name;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

        #endregion

    }
}
