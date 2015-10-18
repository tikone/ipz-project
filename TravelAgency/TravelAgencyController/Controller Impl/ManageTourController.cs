using System;
using System.Linq;

using TravelAgencyModel;
using TravelAgencyOrm;

namespace TravelAgencyController.Controller
{
    class ManageTourController : BasicController, IManageTourController
    {
        public ManageTourController()
        {
            this.m_tourRepository = RepositoryFactory.CreateTourRepository( GetDBContext() );
        }

        public Tour[] GetAllTours()
        {
            return m_tourRepository.LoadAll().ToArray();
        }

        int void CreateNewTour(
                String _country
            ,   String _description
            ,   TourType _type
        )
        {

        }

        public void UpdateCountry(String _country)
        {
        }

        public void UpdateDescription(String _description)
        {

        }

        public void UpdateType(TourType _type)
        {

        }

        private ITourRepository m_tourRepository;
    }
}
