using System;
using System.Collections.Generic;

using TravelAgencyModel;

namespace TravelAgencyController.ViewModel
{
    public class GuidesView : BasicViewModel< GuidesView >
    {
        public String Name { get; set; }

        public ICollection< String > Languages { get; set; }

        public Boolean Available { get; set; }

        public Int32 Phone { get; set; }

        protected override IEnumerable< object > GetAttributesToIncludeInEqualityCheck()
        {
            var list = new List< object > { Name, Available, Phone };
            list.AddRange( Languages );
            return list;
        }

        public override string ToString()
        {
            return string.Format(
                "Name = {0}\nAvailable = {1}\nPhone = {2}\nLanguages:\n{3}",
                Name,
                Available,
                Phone,
                string.Join( "\n\t", Languages )
            );
        }
    }
}
