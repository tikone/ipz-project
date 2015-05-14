using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModel
{
    public class Account
    {

        #region public fields

            public int ID { get; private set; }

            public string Login { get; set; }

            public string Mail { get; set; }

            public int PasswordHash { get; set; }

            public HashSet<Tour> History { get; private set; }

        #endregion

        public Account(
                int _id
            ,    string _login
            ,    string _mail
            ,    int _passwordHash
        )
        {
            ID = _id;
            Login = _login;
            Mail = _mail;
            PasswordHash = _passwordHash;
        }

        public void AddTour( Tour _tour )
        {
            if( History == null )
                History = new HashSet<Tour>();

            History.Add( _tour );

        }

    }
}
