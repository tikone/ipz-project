using System;
using System.IO;

namespace TravelAgencyConsoleClient
{
    abstract class HotelCommand : Command
    {
        protected HotelCommand( string name, TextWriter output )
            : base( name, output )
        {
            AddSwitch( new CommandSwitch( @"-id", CommandSwitch.ValueMode.ExpectSingle, false ) );
        }

        protected int getHotelID( CommandSwitchValues _values )
        {
            return _values.GetSwitchAsInt( @"-id" );
        }
    }
}