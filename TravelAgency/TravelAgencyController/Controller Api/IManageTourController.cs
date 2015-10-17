using System;

using TravelAgencyModel;

namespace TravelAgencyController.Controller
{
    public interface IManageTourController : IDisposable
    {
        Tour[] GetAllTours ();

        void CreateNewTour(
                DateTime _dateTime
            ,   Double _price
            ,   String _country
            ,   String _description
            ,   TourType _type
            ,   Hotel _hotel
            ,   Airline _airline
            ,   Int32 _amountPeople = 1
        );

        void UpdatePrice( Int32 _tourId, Int32 _price);

        void UpdateCountry( String _country );

        void UpdateDescription(String _description);

        void UpadateHotel( Hotel _hotel );

        void UpadateAirline( Airline _airline);

        void UpadateAmountPeople( Int32 _amountPeople );

    }
}
