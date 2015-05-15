using System;
using System.Collections.Generic;

namespace TravelAgencyModel
{
	public class Account
	{

		#region public fields

		public int ID { get; private set; }

		public string Login { get; set; }

		public string Mail { get; set; }

		public int PasswordHash { get; set; }

		#endregion

		#region constructors

		public Account( int _id, string _login, string _mail, int _passwordHash )
        {
			ID = _id;
			Login = _login;
			Mail = _mail;
			PasswordHash = _passwordHash;

            visitedTours = new List<Tour>();
        }

		#endregion

		#region public methods

		public void AddTour( Tour _tour )
		{
			visitedTours.Add( _tour );
		}

		public void forEachTour( Action<Tour> _function )
		{
			foreach( var tour in visitedTours )
			_function( tour );
		}

		#endregion

		#region private fields

		private List<Tour> visitedTours;

		#endregion
	}
}
