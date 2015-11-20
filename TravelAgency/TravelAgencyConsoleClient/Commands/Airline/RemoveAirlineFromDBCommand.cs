using System;
using System.IO;

using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class RemoveAirlineFromDBCommand : AirlineCommand
    {
        public RemoveAirlineFromDBCommand( TextWriter output )
            : base( @"airline.database.remove", output )
        {
        }

        public override void Execute(CommandSwitchValues _values)
        {
            int airlineID = getAirlineID( _values );
            using( var airlineController = ControllerFactory.CreateAirlineController() )
            {
                airlineController.RemoveAirlineFromDB( airlineID );
            }
        }
    }
}
