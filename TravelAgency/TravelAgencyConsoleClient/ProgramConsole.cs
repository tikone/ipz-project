using System;
using System.IO;

using TravelAgencyConsoleClient;

namespace TravelAgencyDemoApp
{
    public class ConsoleProgram
    {
        public static void Main( string[] _args )
        {
            RunCommandProcessingLoop( System.Console.In, System.Console.Out );
        }

        private static void RunCommandProcessingLoop( TextReader _input, TextWriter _output )
        {
            CommandHandler commandHandler = new CommandHandler();

            InitCommands( commandHandler, _output );

            while( true )
            {
                _output.Write( @"> " );
                string command = _input.ReadLine();

                try
                {
                    commandHandler.ProcessCommandLine( command );
                }
                catch (Exception _ex )
                {
                    _output.WriteLine(
                        string.Format(
                            "Error: {0}{1}",
                            _ex.Message,
                            ( _ex.InnerException != null ) ? _ex.InnerException.Message + "\n" : ""
                        )
                    );
                }
            }
        }


        private static void InitCommands( CommandHandler _handler, TextWriter _output )
        {
            _handler.RegisterCommand( new HelpCommand( _handler, _output ) );
            _handler.RegisterCommand( new QuitCommand( _output) );
        }
    }
}
