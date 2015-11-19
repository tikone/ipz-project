using System;
using System.Collections.Generic;

using TravelAgencyModel;

namespace TravelAgencyController.ViewModel
{
    public class AccountView : BasicViewModel< AccountView >
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public ICollection< TourOrderView > History { get; set; }

        protected override IEnumerable< object > GetAttributesToIncludeInEqualityCheck()
        {
            var list = new List< object > { UserID, Login, Mail };
            list.AddRange( History );
            return list;
        }

        public override string ToString()
        {
            return string.Format(
                "UserId = {0}\nLogin = {1}\nMail = {2}\nHistory:\n{2}",
                UserID,
                Login,
                Mail,
                string.Join( "\n\t", History )
            );
        }
    }
}
