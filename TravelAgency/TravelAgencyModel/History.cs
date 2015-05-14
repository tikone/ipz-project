    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModel
{
    class History
    {
        public void AddTour( Tour tour )
        {
            visitedTours.Add(tour);
        }

        private List<Tour> visitedTours;
    }
}
