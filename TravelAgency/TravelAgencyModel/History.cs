using System;
using System.Collections.Generic;

namespace TravelAgencyModel
{
    public class History
    {
        public History()
        {
            visitedTours = new List<Tour>();
        }

		#region public methods

		public void AddTour(Tour tour)
        {
            visitedTours.Add(tour);
        }

        public void viewHistory(Action<Tour> _function)
        {
            foreach (var tour in visitedTours)
                _function(tour);
        }

		#endregion

		#region private fields

		private List<Tour> visitedTours;

		#endregion
	}
}
