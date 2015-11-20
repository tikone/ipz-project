using System;
using System.IO;
using System.Collections.Generic;

using TravelAgencyController.Controller;
using TravelAgencyController.ViewModel;

namespace TravelAgencyConsoleClient
{
    class TourShowCommand : Command
    {
        public TourShowCommand( TextWriter output )
            : base( @"tour.show", output )
        {
            AddSwitch(new CommandSwitch( @"-id", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch( new CommandSwitch( @"-country", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch( new CommandSwitch( @"-description", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch( new CommandSwitch( @"-type", CommandSwitch.ValueMode.ExpectSingle, true ) );
        }

        public override void Execute( CommandSwitchValues _values )
        {
            using (var manageTourController = ControllerFactory.CreateManageTourController())
            {
                List< TourView  > result = new List< TourView >();
                var toursView = manageTourController.ViewAllTours();
                foreach ( var tourView in toursView )
                    if( shouldAddTour( _values, tourView ) )
                        result.Add( tourView );

                ReportValues( result );
            }
        }

        private bool shouldAddTour( CommandSwitchValues _values, TourView _tourView )
        {
            string tourID = _values.GetOptionalSwitch( @"-id" );
            if( tourID != null && _tourView.TourID.ToString() != tourID )
                return false;

            string country = _values.GetOptionalSwitch( @"-country" );
            if( country != null && _tourView.Country != country )
                return false;

            string description = _values.GetOptionalSwitch( @"-description" );
            if( description != null && _tourView.Description != description )
                return false;

            string type = _values.GetOptionalSwitch( @"-type" );
            if( type != null && _tourView.Type != type )
                return false;

            return true;
        }
    }
}
