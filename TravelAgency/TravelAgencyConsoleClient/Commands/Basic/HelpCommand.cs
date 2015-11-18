using System;
using System.IO;
using System.Collections.Generic;

namespace TravelAgencyConsoleClient
{
    class HelpCommand : Command
    {
        public HelpCommand( CommandHandler _handler, TextWriter _output )
            :   base( @"help", _output )
        {
            AddSwitch( new CommandSwitch( @"-command", CommandSwitch.ValueMode.ExpectSingle, true ) );

            this.handler = _handler;
        }

        public override void Execute( CommandSwitchValues _values )
        {
            string commandName = _values.GetOptionalSwitch( "-command" );
            if( commandName != null )
            {
                Command command = handler.FindCommand( commandName );
                if( command == null )
                    throw new Exception( "help: command " + commandName + " not found" );

                ShowHelpFor( command );
            }

            else
            {
                foreach( string name in handler.CommandNames )
                    ShowHelpFor( handler.FindCommand( name ) );
            }
        }

        private void ShowHelpFor( Command _command )
        {
            Output.Write( _command.Name );
            foreach (string switchName in _command.SwitchNames )
            {
                Output.Write( ' ' );

                CommandSwitch sw = _command.FindSwitch(switchName);

                if( sw.Optional )
                    Output.Write( '[' );

                if( sw.Mode == CommandSwitch.ValueMode.ExpectMultiple )
                    Output.Write( '{' );

                Output.Write( switchName );

                if( sw.Mode != CommandSwitch.ValueMode.Unexpected )
                    Output.Write( @" <value>" );

                if( sw.Mode == CommandSwitch.ValueMode.ExpectMultiple )
                    Output.Write( '}' );

                if( sw.Optional )
                    Output.Write( ']' );
            }
            Output.WriteLine();
        }

        private CommandHandler handler;
    }
}
