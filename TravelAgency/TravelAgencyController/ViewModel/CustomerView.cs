using System;
using System.Collections.Generic;

using TravelAgencyModel;

namespace TravelAgencyController.ViewModel
{
    public class CustomerView : BasicViewModel< CustomerView >
    {
        public Int32 CustomerID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Account Account { get; set; }

        protected override IEnumerable< object > GetAttributesToIncludeInEqualityCheck()
        {
            var list = new List< object > { CustomerID, Name, Surname, Account };
            return list;
        }

        public override string ToString()
        {
            return string.Format(
                "CustomerID = {0}\nName = {1}\nSurname = {2}\nAccount:\n{3}",
                CustomerID,
                Name,
                Surname,
                Account.ToString()
            );
        }
    }
}
