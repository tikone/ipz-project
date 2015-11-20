using System;
using System.IO;

using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class AddAirlineToDBCommand : Command
    {
        public AddAirlineToDBCommand( TextWriter output )
            : base( @"airline.database.add", output )
        {
            AddSwitch( new CommandSwitch( @"-name", CommandSwitch.ValueMode.ExpectSingle, false ) );
        }

        public override void Execute( CommandSwitchValues _values )
        {
            string airlineName = _values.GetSwitch( @"-name");
            using (var airlineController = ControllerFactory.CreateAirlineController() )
            {
                airlineController.AddNewAirlineToDB( airlineName );
            }
        }
    }
}
