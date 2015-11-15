using System;
using System.Collections.Generic;

using TravelAgencyModel;

namespace TravelAgencyController.ViewModel
{
    public class AirlineView : BasicViewModel< AirlineView >
    {
        public int AirlineID { get; set; }

        public String Name { get; set; }

        public ICollection< Ticket > Tickets { get; set; }

        protected override IEnumerable< object > GetAttributesToIncludeInEqualityCheck()
        {
            var list = new List< object > { AirlineID, Name };
            list.AddRange( Tickets );
            return list;
        }

        public override string ToString()
        {
            return string.Format(
                "AirlineID = {0}\nName = {1}\nTickets:\n{2}",
                AirlineID,
                Name,
                string.Join( "\n\t", Tickets )
            );
        }
    }
}
