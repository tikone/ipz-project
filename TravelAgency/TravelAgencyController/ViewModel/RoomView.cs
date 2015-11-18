using System;
using System.Collections.Generic;

namespace TravelAgencyController.ViewModel
{
    public class RoomView : BasicViewModel<RoomView>
    {
        public Int32 Number { get; set; }
        public String BedNumber { get; set; }
        public Boolean Reserved { get; set; }
        public String TypeOfBeds { get; set; }
        public String TypeOfRoom { get; set; }


        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            var list = new List<object> { Number, BedNumber, Reserved, TypeOfBeds, TypeOfRoom };
            return list;
        }


        public override string ToString()
        {
            return string.Format(
                       "Number = {0}\nBedNumber = {1}\nReserved = {2}\nTypeOfBeds = {3}\nTypeOfRoom = {4}\n",
                       Number,
                       BedNumber,
                       Reserved,
                       TypeOfBeds,
                       TypeOfRoom
                   );
        }
    }
}
