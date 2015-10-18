using System;

using TravelAgencyModel;

namespace TravelAgencyController.Controller
{
    public interface IManageTourController : IDisposable
    {
        Tour[] GetAllTours ();

        void CreateNewTour(
                String _country
            ,   String _description
            ,   TourType _type
        );

        void UpdateCountry( String _country );

        void UpdateDescription(String _description);

        void UpdateType( TourType _type );

    }
}
