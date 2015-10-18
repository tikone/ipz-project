using System;

using TravelAgencyModel;

namespace TravelAgencyController.Controller
{
    public interface IManageTourController : IDisposable
    {
        Tour[] GetAllTours ();

        Int32 CreateNewTour(
                String _country
            ,   String _description
            ,   TourType _type
        );

        void UpdateCountry( Int32 _id, String _country );

        void UpdateDescription( Int32 _id, String _description);

        void UpdateType( Int32 _id, TourType _type );

    }
}
