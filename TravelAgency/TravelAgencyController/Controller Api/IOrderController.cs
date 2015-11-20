using System;
using System.Collections.Generic;

using TravelAgencyModel;
using TravelAgencyController.ViewModel;

namespace TravelAgencyController.Controller
{
    public interface IOrderController : IDisposable
    {

        TourOrder[] GetAllOrders ();

        ICollection< TourOrderView > ViewAllTourOrders();

        void CreateNewTourOrder(
                Int32 _tourId
            ,   DateTime _dateTime
            ,   Double _price
            ,   Customer _customer
            ,   Int32 _amountPeople = 1
        );

        void UpdateDateTime( Int32 _id, DateTime _dateTime );

        void DropOrder( Int32 _id );

    }
}
