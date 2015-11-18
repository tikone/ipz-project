using System;
using System.Collections.Generic;

namespace TravelAgencyController.ViewModel
{
    public class TourView : BasicViewModel<TourView>
    {
        public Int32 TourID { get; set; }
        public String Country { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }


        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            var list = new List<object> { TourID, Country, Type, Description };
            return list;
        }


        public override string ToString()
        {
            return string.Format(
                       "TourID = {0}\nCountry = {1}\nType = {2}\nDescription = {3}\n",
                       TourID,
                       Country,
                       Type,
                       Description
                   );
        }
    }
}
