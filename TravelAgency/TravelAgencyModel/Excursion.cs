using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	class Excursion
	{
		public String Name { get; set; }

		public Double Price { get; set; }

		public DateTime Date_Time { get; set; } // add date / time class

		private List<Guide> m_guides;

		public HashSet<String> getAvailableLanguages()
		{
			HashSet<String> languages = new HashSet<string>();

			foreach (Guide guide in m_guides)
				if( guide.Available )
				languages.Add(guide.Language);

			return languages;
		}
	}
}
