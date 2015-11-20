using System;
using System.IO;

namespace TravelAgencyConsoleClient
{
    abstract class AirlineCommand : Command
    {
        protected AirlineCommand( string name, TextWriter output )
            : base( name, output )
        {
            AddSwitch( new CommandSwitch( @"-id", CommandSwitch.ValueMode.ExpectSingle, false ) );
        }

        protected int getAirlineID( CommandSwitchValues _values )
        {
            return _values.GetSwitchAsInt( @"-id" );
        }
    }
}