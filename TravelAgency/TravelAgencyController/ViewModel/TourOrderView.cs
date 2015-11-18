﻿using System;
using System.Collections.Generic;

namespace TravelAgencyController.ViewModel
{
    public class TourView : BasicViewModel<TourView>
    {
        public Int32 TourOrderID { get; set; }
        public String DateTime { get; set; }
        public Double Price { get; set; }
        public List<TicketView> Tickets { get; set; }

        public HashSet<RoomView> Rooms { get; set; }

        public HashSet<ExcursionView> Excursions { get; set; }


        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            var list = new List<object> { TourOrderID, DateTime, Price };
            list.AddRange(Tickets);
            list.AddRange(Rooms);
            list.AddRange(Excursions);
            return list;
        }


        public override string ToString()
        {
            return string.Format(
                       "TourOrderID = {0}\nDateTime = {1}\nPrice = {2}\nTickets = {3}\nRooms = {4}\nExcursions = {5}\n",
                       TourOrderID,
                       DateTime,
                       Price,
                       string.Join( "\n\t", Tickets),
                       string.Join( "\n\t", Rooms),
                       string.Join( "\n\t", Excursions)
                   );
        }
    }
}
