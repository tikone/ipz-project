using System;
using System.IO;

using TravelAgencyModel;
using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class TourOrderChangeDateTimeCommand : TourOrderCommand
    {
        public TourOrderChangeDateTimeCommand( TextWriter output )
            : base( @"tour.order.change.dateTime", output )
        {
            AddSwitch( new CommandSwitch( @"-dateTime", CommandSwitch.ValueMode.ExpectSingle, false ) );
        }

        public override void Execute( CommandSwitchValues _values )
        {
            using( var tourOrderController = ControllerFactory.CreateOrderController() )
            {
                tourOrderController.UpdateDateTime(
                    getTourOrderID( _values ),
                    DateTime.Parse( _values.GetSwitch( @"-dateTime" ) )
                );
            }
        }
    }
}