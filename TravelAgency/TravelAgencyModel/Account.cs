using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModel
{
    class Account
    {
        public int ID { get; private set; }

		public string Login { get; set; }

		public string Mail { get; set; }

		public int PasswordHash { get; set; }

        public Account( int _id, string _login, string _mail, int _passwordHash )
        {
			ID = _id;
			Login = _login;
			Mail = _mail;
			PasswordHash = _passwordHash;

            history = new History();
        }

        public void AddTour( Tour _tour )
        {
            history.AddTour(_tour);
        }

        private int passwordHash;

        private History history;
    }
}
