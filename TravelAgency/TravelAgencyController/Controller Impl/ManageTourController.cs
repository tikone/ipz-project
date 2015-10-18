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

        public Int32 CreateNewTour(
                String _country
            ,   String _description
            ,   TourType _type
        )
        {
            Tour tour = new Tour( _country, _description, _type );
            m_tourRepository.Add( tour );

            return tour.TourID;

        }

        public void UpdateCountry(Int32 _id, String _country)
        {
            Tour tour = FindObjectById( m_tourRepository, _id );

            tour.Country = _country;
        }

        public void UpdateDescription(Int32 _id, String _description)
        {
            Tour tour = FindObjectById(m_tourRepository, _id);

            tour.Description = _description;
        }

        public void UpdateType(Int32 _id, TourType _type)
        {
            Tour tour = FindObjectById(m_tourRepository, _id);

            tour.Type = _type;
        }

        private ITourRepository m_tourRepository;
    }
}
