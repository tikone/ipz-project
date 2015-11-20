using System;
using System.IO;

using TravelAgencyModel;
using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class TourOrderPriceCommand : TourOrderCommand
    {
        public TourOrderPriceCommand( TextWriter output )
            : base( @"tour.order.price", output )
        {
        }

        public override void Execute( CommandSwitchValues _values )
        {
            int tourOrderID = getTourOrderID( _values );
            using( var tourOrderController = ControllerFactory.CreateOrderController() )
            {
                var tourOrdersView = tourOrderController.ViewAllTourOrders();
                foreach( var view in tourOrdersView )
                    if( tourOrderID == view.TourOrderID )
                    {
                        Output.WriteLine( string.Format( "Price for tour: {0}", view.Price ) );
                        break;
                    }
            }
        }
    }
}