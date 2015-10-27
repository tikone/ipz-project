using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TravelAgencyModel
{
    public class Account
    {

        #region public fields

            public int ID { get; private set; }

            public string Login { get; set; }

            public string Mail { get; set; }

            public int PasswordHash { get; set; }

            public virtual ICollection<TourOrder> History { get; private set; }

        #endregion

        public Account(
                int _id
            ,   string _login
            ,   string _mail
            ,   int _passwordHash
        )
        {
            checkLogin(_login);
            checkMail( _mail );
            ID = _id;
            Login = _login;
            Mail = _mail;
            PasswordHash = _passwordHash;
        }

        protected Account() { }

        public void AddTourOrder(TourOrder _tour)
        {
            if( History == null )
                History = new HashSet< TourOrder >();

            History.Add( _tour );
        }

        private void checkMail( String _mail )
        {
            string expr = @"^([a-z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-z0-9\-]+\.)+))([a-z]{2,4}|[0-9]{1,3})(\]?)$";  
            Match isMatch =
                Regex.Match( _mail, expr, RegexOptions.IgnoreCase );

            if( !isMatch.Success )
                throw new ArgumentException( "Invalid sign in mail adress" );
        }

        private void checkLogin( String _login )
        {
            if( _login.Length < 4 || _login.Length > 17 )
                throw new ArgumentException( "Login length should be more then 3 and less then 16 symbols" );

            string expr = @"^[a-z0-9_.]+$";

            Match isMatch =
                Regex.Match( _login, expr, RegexOptions.IgnoreCase );   

            if (!isMatch.Success)
                throw new ArgumentException( "Invalid sign in login" );
        }

    }
}
