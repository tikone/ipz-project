using System;

using TravelAgencyModel;

namespace TravelAgencyController.Controller
{
    public interface IOrderController : IDisposable
    {

        TourOrder[] GetAllOrders ();

        void CreateNewTourOrder(
                Tour _tour
            ,   DateTime _dateTime
            ,   Double _price
            ,   Int32 _amountPeople = 1
        );

        void UpdateDateTime( Int32 _id, DateTime _dateTime );

        void DropOrder( Int32 _id );

    }
}
