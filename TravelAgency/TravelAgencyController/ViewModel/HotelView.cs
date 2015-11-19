using System;
using System.Collections.Generic;

namespace TravelAgencyController.ViewModel
{
    public class HotelView : BasicViewModel<HotelView>
    {
        public Int32 HotelId { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String HotelType { get; set; }
        public ICollection< RoomView > Rooms { get; set; }


        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            var list = new List<object> { HotelId, Name, Address, HotelType };
            list.AddRange( Rooms );
            return list;
        }


        public override string ToString()
        {
            return string.Format(
                       "HotelId = {0}\nName = {1}\nAddress = {2}\nHotelType = {3}\nRooms = {4}\n",
                       HotelId,
                       Name,
                       Address,
                       HotelType,
                       string.Join( "\n\t", Rooms )
                   );
        }
    }
}
