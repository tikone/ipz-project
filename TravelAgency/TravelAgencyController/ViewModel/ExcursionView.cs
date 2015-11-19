using System;
using System.Collections.Generic;

using TravelAgencyModel;

namespace TravelAgencyController.ViewModel
{
    public class ExcursionView : BasicViewModel< ExcursionView >
    {
        public Int32 ExcursionID { get; set; }

        public String Name { get; set; }

        public Double Price { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection< GuidesView > Guides { get; set; }

        protected override IEnumerable< object > GetAttributesToIncludeInEqualityCheck()
        {
            var list = new List< object > { ExcursionID, Name, Price, DateTime };
            list.AddRange( Guides );
            return list;
        }

        public override string ToString()
        {
            return string.Format(
                "ExcursionID = {0}\nName = {1}\nPrice = {2}\nDateTime = {3}\nGuides:\n{4}",
                ExcursionID,
                Name,
                DateTime.ToString(),
                string.Join( "\n\t", Guides )
            );
        }
    }
}
