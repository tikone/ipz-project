using System;
using System.Collections.Generic;
using System.IO;

using TravelAgencyController.Controller;
using TravelAgencyController.ViewModel;

namespace TravelAgencyConsoleClient
{
    class ShowTourOrderCommand : Command
    {
        public ShowTourOrderCommand( TextWriter output )
            : base( @"tour.order.show", output )
        {
            AddSwitch( new CommandSwitch( @"-id", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch( new CommandSwitch( @"-dateTime", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch( new CommandSwitch( @"-price", CommandSwitch.ValueMode.ExpectSingle, true ) );
        }

        public override void Execute(CommandSwitchValues _values)
        {
            using( var tourOrderController = ControllerFactory.CreateOrderController() )
            {
                List< TourOrderView > result = new List< TourOrderView >();
                var tourOrdersView = tourOrderController.ViewAllTourOrders();
                foreach( var view in tourOrdersView )
                    if( shouldAddAirline( _values, view ) )
                        result.Add( view );

                ReportValues( result );
            }
        }

        private bool shouldAddAirline( CommandSwitchValues _values, TourOrderView _tourOrderView )
        {
            string tourOrderID = _values.GetOptionalSwitch( @"-id" );
            if( tourOrderID != null && _tourOrderView.TourOrderID.ToString() != tourOrderID )
                return false;

            string dateTime = _values.GetOptionalSwitch( @"-dateTime" );
            if( dateTime != null && _tourOrderView.DateTime.ToString() != dateTime )
                return false;

            string price = _values.GetOptionalSwitch( @"-price" );
            if (price != null && _tourOrderView.Price.ToString() != price )
                return false;

            return true;
        }
    }
}