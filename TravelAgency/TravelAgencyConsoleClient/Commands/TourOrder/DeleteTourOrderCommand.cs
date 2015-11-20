using System;
using System.IO;

using TravelAgencyModel;
using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class DeleteTourOrderCommand : TourOrderCommand
    {
        public DeleteTourOrderCommand( TextWriter output )
            : base( @"tour.order.delete", output )
        {
        }

        public override void Execute( CommandSwitchValues _values )
        {
            using( var tourOrderController = ControllerFactory.CreateOrderController() )
            {
                tourOrderController.DropOrder( getTourOrderID( _values ) );
            }
        }
    }
}