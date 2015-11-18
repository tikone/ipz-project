using System;
using System.Collections.Generic;

namespace TravelAgencyConsoleClient
{
    class CommandHandler
    {
        public CommandHandler()
        {
            this.commands = new SortedDictionary< string, Command >();
        }

        public IEnumerable< string > CommandNames
        {
            get { return commands.Keys; }
        }

        public void RegisterCommand( Command _command )
        {
            if( commands.ContainsKey( _command.Name ) )
                throw new Exception( "CommandSyntax: duplicate command" );

            commands.Add( _command.Name, _command );
        }

        public Command FindCommand( string _commandName )
        {
            Command command;
            if( commands.TryGetValue( _commandName, out command ) )
                return command;

            return null;
        }

        public void ProcessCommandLine( string _commandLine )
        {
            string[] parts = _commandLine.Trim().Split( ' ', '\t' );
            if( parts.Length == 0 )
                return;

            string commandName = parts[0];
            if( commandName.Length == 0 )
                return;

            Command command;
            if( !commands.TryGetValue( commandName, out command ) )
                throw new Exception( "CommandSyntax: unknown command" );

            var values = new CommandSwitchValues();
            for( int i = 1; i < parts.Length; i++ )
            {
                string switchName = parts[i];
                CommandSwitch sw = command.FindSwitch( switchName );
                if( sw == null )
                    throw new Exception( "CommandSyntax: unsupported switch " + switchName );

                switch( sw.Mode )
                {
                    case CommandSwitch.ValueMode.Unexpected:
                        values.SetSwitch( switchName, "true" );
                    break;

                    case CommandSwitch.ValueMode.ExpectSingle:
                        values.SetSwitch( switchName, parts[i + 1] );
                        ++i;
                    break;

                    case CommandSwitch.ValueMode.ExpectMultiple:
                        values.AppendSwitch( switchName, parts[i + 1] );
                        ++i;
                    break;

                    default:
                        throw new Exception( "CommandSyntax: unexpected switch value mode" );
                }
            }

            foreach( string switchName in command.SwitchNames )
            {
                CommandSwitch sw = command.FindSwitch( switchName );
                if( !sw.Optional && !values.HasSwitch( switchName ) )
                    throw new Exception( "CommandSyntax: switch " + switchName + " must be specified." );
            }

            command.Execute( values );
        }

        private IDictionary< string, Command > commands;
    }
}