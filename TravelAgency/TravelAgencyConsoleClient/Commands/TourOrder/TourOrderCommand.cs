using System;
using System.IO;

namespace TravelAgencyConsoleClient
{
    abstract class TourOrderCommand : Command
    {
        protected TourOrderCommand( string name, TextWriter output )
            : base( name, output )
        {
            AddSwitch( new CommandSwitch( @"-id", CommandSwitch.ValueMode.ExpectSingle, false ) );
        }

        protected int getTourOrderID( CommandSwitchValues _values )
        {
            return _values.GetSwitchAsInt( @"-id" );
        }
    }
}