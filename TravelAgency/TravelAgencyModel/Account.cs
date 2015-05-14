using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModel
{
    class Account
    {
        public int ID { public get { return id; } private set; }

        public string Login { public get { return login; } private set; }

        public string Mail { public get { return mail; } private set; }
    
        public int PasswordHash { public get { return passwordHash; } private set; }

        public Account( int _id, string _login, string _mail, int _passwordHash )
        {
            id = _id;
            login = _login;
            mail = _mail;
            passwordHash = _passwordHash;

            history = new History();
        }

        public void AddTour( Tour _tour )
        {
            history.AddTour(_tour);
        }

        public void changePassword( int _newPasswordHash )
        {
            passwordHash = _newPasswordHash;
        }

        public void changeLogin(string _newLogin)
        {
            login = _newLogin;
        }

        public void changeMail(string _newMail)
        {
            mail = _newMail;
        }

        private int id;

        private string login;
        
        private string mail;

        private int passwordHash;

        private History history;
    }
}
