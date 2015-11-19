using System;
using System.Collections.Generic;
using System.IO;

namespace TravelAgencyConsoleClient
{
    class ConsoleClearCommand : Command
    {
        public ConsoleClearCommand( TextWriter _output )
            : base( @"console.clear", _output )
        {
        }

        public override void Execute( CommandSwitchValues _values )
        {
            Console.Clear();
        }
    }
}