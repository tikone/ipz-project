using System;
using System.IO;
using System.Collections.Generic;

using TravelAgencyController.Controller;
using TravelAgencyController.ViewModel;

namespace TravelAgencyConsoleClient
{
    class ShowAirlineCommand : Command
    {
        public ShowAirlineCommand( TextWriter output )
            : base( @"airline.show", output )
        {
            AddSwitch(new CommandSwitch( @"-id", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch(new CommandSwitch( @"-name", CommandSwitch.ValueMode.ExpectSingle, true ) );
        }

        public override void Execute(CommandSwitchValues _values)
        {
            using( var airlineController = ControllerFactory.CreateAirlineController() )
            {
                List< AirlineView > result = new List< AirlineView >();
                var airlinesView = airlineController.ViewAllAirlines();
                foreach( var view in airlinesView )
                    if( shouldAddAirline( _values, view ) )
                        result.Add( view );

                ReportValues( result );
            }
        }

        private bool shouldAddAirline( CommandSwitchValues _values, AirlineView _airlineView )
        {
            string airlineID = _values.GetOptionalSwitch( @"-id" );
            if (airlineID != null && _airlineView.AirlineID.ToString() != airlineID )
                return false;

            string name = _values.GetOptionalSwitch( @"-name" );
            if( name != null && _airlineView.Name != name )
                return false;

            return true;
        }
    }
}