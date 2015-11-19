using System;
using System.IO;

using TravelAgencyConsoleClient;
using TravelAgencyModel;
using TravelAgencyController.Controller;

namespace TravelAgencyDemoApp
{
    public class ConsoleProgram
    {
        public static void Main( string[] _args )
        {
            GenerateInitialContent();
            RunCommandProcessingLoop( System.Console.In, System.Console.Out );
        }

        private static void GenerateInitialContent()
        {
            using( var controller = ControllerFactory.CreateManageTourController() )
            {
                AddBeerTour( controller );
                AddBeachTour( controller );
            }
        }

        private static void AddBeerTour( IManageTourController _controller )
        {
            _controller.CreateNewTour(
                    @"UA"
                ,   @"best tour EU"
                ,   TourType.Beer
            );
        }

        private static void AddBeachTour( IManageTourController _controller )
        {
            _controller.CreateNewTour(
                    @"UA"
                ,   @"nice tour"
                ,   TourType.Beach
            );
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
            _handler.RegisterCommand( new ConsoleClearCommand( _output ) );
            _handler.RegisterCommand( new ShowToursCommand( _output ) );
            _handler.RegisterCommand( new CreateTourCommand(_output) );
            _handler.RegisterCommand( new EditTourCommand( _output ) );
        }
    }
}
