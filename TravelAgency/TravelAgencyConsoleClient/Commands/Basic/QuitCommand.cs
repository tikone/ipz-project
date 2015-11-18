using System;
using System.Collections.Generic;
using System.IO;

namespace TravelAgencyConsoleClient
{
    class QuitCommand : Command
    {
        public QuitCommand( TextWriter _output )
            : base( @"quit", _output )
        {
        }

        public override void Execute( CommandSwitchValues _values )
        {
            Output.WriteLine( @"Good Bye!" );
            Environment.Exit( 0 );
        }
    }
}