using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	public class Excursion
	{

		#region public fields

		public String Name { get; set; }

		public Double Price { get; set; }

		public DateTime Date_Time { get; set; }

		private List<Guide> m_guides;

		#endregion

		public Excursion( String _name, Double _price, DateTime _dateTime )
		{
			this.Name = _name;
			this.Price = _price;
			this.Date_Time = _dateTime;

			m_guides = new List<Guide>();
		}

		#region public methods

		public HashSet<String> getAvailableLanguages()
		{
			HashSet<String> languages = new HashSet<string>();

			foreach (Guide guide in m_guides)
				if( guide.Available )
				languages.Add(guide.Language);

			return languages;
		}

		#endregion
	}
}
