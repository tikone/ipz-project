using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Ticket
    {

        #region public fields

            public Int32 TicketID { get; set; }

            public DateTime Departure { get; set; }

            public DateTime ArrivalDate { get; set; }

            public Boolean Reserved { get; set; }

            public String NumberOfAirplane { get; set; }

            public String ArrivalCountry { get; set; }

            public TicketType Type { get; set; }

        #endregion

        public Ticket (
                DateTime _departure
            ,   DateTime _arrivalDate
            ,   String _numberOfAirplane
            ,   String _arrivalContry
            ,   TicketType _type
        )
        {
            this.Departure = _departure;
            this.ArrivalDate = _arrivalDate;
            this.NumberOfAirplane = _numberOfAirplane;
            this.ArrivalCountry = _arrivalContry;
            this.Type = _type;
            this.Reserved = false;
        }

        protected Ticket() { }

        #region override

            public override String ToString()
            {
                var builder = new StringBuilder();

                String sep = @"  ";
                builder.Append(this.Departure);
                builder.Append(sep);
                builder.Append(this.ArrivalDate);
                builder.Append(sep);
                builder.Append(this.ArrivalCountry);
                builder.Append(sep);
                builder.Append(this.NumberOfAirplane);
                builder.Append(sep);
                builder.Append(this.Type);

                return builder.ToString();
            }

        #endregion

    }
}
