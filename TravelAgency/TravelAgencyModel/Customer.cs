using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModel
{
    public class Customer
    {

        #region public fields

            public Int32 ID { get; set; }

            public string Name { get; private set; }

            public string Surname { get; private set; }

            public virtual Account Account { get; private set; }

        #endregion

        protected Customer() { }

        public Customer( string _name, string _surname )
        {
            if ( _name.Length == 0 || _surname.Length == 0 )
                throw new ArgumentException( @"Customer full name should be filled" );

            Name = _name;
            Surname = _surname;
        }

        #region public methods

            public bool IsRegistered()
            {
                return Account != null;
            }

            public bool Registrate(
                    int _id
                ,   string _login
                ,   string _mail
                ,   int _passwordHash
            )
            {
                if( IsRegistered() )
                    return false;

                Account = new Account( _id, _login, _mail, _passwordHash );

                return true;
            }

            public void addTour( TourOrder _tour )
            {
                if( !IsRegistered() )
                    return;

                Account.AddTourOrder(_tour);

            }

        #endregion
    }
}
