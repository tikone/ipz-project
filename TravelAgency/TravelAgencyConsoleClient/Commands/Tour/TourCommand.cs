using System;
using System.IO;

namespace TravelAgencyConsoleClient
{
    abstract class TourCommand : Command
    {
        protected TourCommand( string name, TextWriter output )
            : base( name, output )
        {
            AddSwitch( new CommandSwitch( "-id", CommandSwitch.ValueMode.ExpectSingle, false ) );
        }

        protected int GetTourID( CommandSwitchValues _values )
        {
            return _values.GetSwitchAsInt( "-id" );
        }
    }
}