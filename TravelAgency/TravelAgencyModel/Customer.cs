using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModel
{
    class Customer
    {
		public string Name { get; private set; }
        
		public string Surname { get; private set; }

        public Account Account { get; private set; }

        public Customer( string _name, string _surname )
        {
			Name = _name;
			Surname = _surname;
        }

        public bool IsRegistered()
        {
            return Account != null;
        }

        public bool Registrate(
                int _id
            ,   string _login
            ,   string _mail
            ,   int _passwordHash )
        {
            if( IsRegistered() )
                return false;

            Account = new Account(_id, _login, _mail, _passwordHash);

            return true;
        }

        public void addTour( Tour _tour )
        {
            if (!IsRegistered() )
                return;

            Account.AddTour(_tour);

        }

    }
}
