using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

using TravelAgencyController.Controller;
using TravelAgencyModel;

namespace TravelAgencyFitNesse
{
    public class OrderControllerFixture
    {
        
        private IOrderController orderController;

        private Int32 tourId;
        private DateTime date;
        private Double price;
        private Int32 ammountPeople;
        private Customer customer;
        private bool isTourOrded;

        public OrderControllerFixture()
        {
            orderController = ControllerFactory.CreateOrderController();
            customer = new Customer( "Vasya", "Pupkin" );
            isTourOrded = false;
        }

        public void enterIs ( string field, string argument )
        {
            switch( field )
            {
                case "id":
                    tourId = int.Parse(argument);
                break;
                case "date":
                    date = DateTime.ParseExact(argument, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                break;
                case "price":
                    price = Double.Parse(argument);
                break;
                case "ammount_people":
                    ammountPeople = int.Parse(argument);
                break;
            }
        }

        public void create()
        {
            checkInput( tourId );
            checkInput( date );
            checkInput( price );
            checkInput( ammountPeople );

            orderController.CreateNewTourOrder(
                    tourId
                ,   date
                ,   price
                ,   customer
                ,   ammountPeople
            );

            isTourOrded = true;
        }

        public void updateDate( string argument )
        {
            if( !isTourOrded )
                throw new Exception( "Tour must be created" );

            date = DateTime.ParseExact(argument, "yyyy-MM-dd", CultureInfo.InvariantCulture); ;

            orderController.UpdateDateTime( tourId, date );
        }

        public void drop()
        {
            if( !isTourOrded )
                throw new Exception( "Tour must be created" );

            orderController.DropOrder( tourId );
        }

        private void checkInput<_TType>(_TType _obj)
        {
            if (_obj == null)
                throw new NullReferenceException( "Not all fields is set");
        }

    }
}
