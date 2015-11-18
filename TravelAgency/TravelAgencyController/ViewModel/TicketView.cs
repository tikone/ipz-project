using System;
using System.Collections.Generic;

namespace TravelAgencyController.ViewModel
{
    public class TicketView : BasicViewModel<TicketView>
    {
        public Int32 TicketID { get; set; }
        public String Departure { get; set; }
        public String ArrivalDate { get; set; }
        public Boolean Reserved { get; set; }
        public String NumberOfAirplane { get; set; }
        public String ArrivalCountry { get; set; }
        public String Type { get; set; }


        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            var list = new List<object> { TicketID, Departure, ArrivalDate, Reserved, NumberOfAirplane, ArrivalCountry, Type };
            return list;
        }


        public override string ToString()
        {
            return string.Format(
                       "TicketID = {0}\nDeparture = {1}\nArrivalDate = {2}\nReserved = {3}\nNumberOfAirplane = {4}\nArrivalCountry = {5}\nType = {6}\n",
                       TicketID,
                       Departure,
                       ArrivalDate,
                       Reserved,
                       NumberOfAirplane,
                       ArrivalCountry,
                       Type
                   );
        }
    }
}
