using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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

            using (var controller = ControllerFactory.CreateAirlineController())
            {
                controller.CreateNewTicket(
                    new DateTime( 2015, 12, 29), 
                    new DateTime( 2015, 12, 31),
                    @"1A",
                    @"Mountlandia",
                    TicketType.BusinessClass
                );
            }

            CreateTestOrder1();
            CreateTestOrder2();
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

        private static void CreateTestOrder1()
        {
            using (var controller = ControllerFactory.CreateOrderController())
            {
                var manageController = ControllerFactory.CreateManageTourController();

                var tour = manageController.GetAllToursLINQ().Where(
                    _tour => _tour.Country.Equals( @"UA" ) && _tour.Description.Equals( @"best tour EU" )
                );

                //TODO: create customer controller for represetation customer actions and CRUD operations
                var customer = new Customer( "Bolik", "Pupkin" );

                controller.CreateNewTourOrder(
                        tour.First().TourID
                    , new DateTime( 2015, 5, 12 )
                    , 999.99
                    , customer
                );

            }
        }

        private static void CreateTestOrder2()
        {
            using( var controller = ControllerFactory.CreateOrderController() )
            {
                var manageController = ControllerFactory.CreateManageTourController();

                var tour = manageController.GetAllToursLINQ().Where(
                    _tour => _tour.Country.Equals( @"UA" ) && _tour.Description.Equals( @"nice tour" )
                );

                var customer = new Customer( "Lolik", "Pupkin" );

                controller.CreateNewTourOrder(
                        tour.First().TourID
                    , new DateTime( 2015, 9, 12 )
                    , 339.99
                    , customer
                );

            }
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

            _handler.RegisterCommand( new ShowAllToursCommand( _output ) );
            _handler.RegisterCommand( new TourShowCommand( _output ) );
            _handler.RegisterCommand( new CreateTourCommand(_output) );
            _handler.RegisterCommand( new EditTourCommand( _output ) );

            _handler.RegisterCommand( new AddAirlineToDBCommand( _output ) );
            _handler.RegisterCommand( new RemoveAirlineFromDBCommand( _output ) );
            _handler.RegisterCommand( new ShowAirlineCommand( _output ) );
            _handler.RegisterCommand( new AirlineAddTicketCommand( _output ) );
            _handler.RegisterCommand( new AirlineTicketShowCommand( _output ) );
            _handler.RegisterCommand( new ShowAvailableTickets( _output ) );

            //TODO: add supporting string switches like -switch " some long name with whitespaces"
            _handler.RegisterCommand( new DeleteTourOrderCommand( _output ) );
            _handler.RegisterCommand( new TourOrderChangeDateTimeCommand( _output ) );
            _handler.RegisterCommand( new ShowTourOrderCommand( _output ) );
            _handler.RegisterCommand( new TourOrderPriceCommand( _output ) );

            _handler.RegisterCommand( new AddHotelToDBCommand( _output ) );
            _handler.RegisterCommand( new RemoveHoteFromDBCommand( _output ) );
            _handler.RegisterCommand( new ShowHotelCommand( _output ) );
        }
    }
}
