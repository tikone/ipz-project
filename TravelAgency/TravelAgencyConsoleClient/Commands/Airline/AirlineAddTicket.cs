using System;
using System.IO;

using TravelAgencyModel;
using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class AirlineAddTicketCommand : AirlineCommand
    {
        public AirlineAddTicketCommand( TextWriter output )
            : base( @"airline.add.ticket", output )
        {
            AddSwitch( new CommandSwitch( @"-departure", CommandSwitch.ValueMode.ExpectSingle, false ) );
            AddSwitch( new CommandSwitch( @"-arrivalDate", CommandSwitch.ValueMode.ExpectSingle, false ) );
            AddSwitch( new CommandSwitch( @"-airplane_number", CommandSwitch.ValueMode.ExpectSingle, false ) );
            AddSwitch( new CommandSwitch( @"-arrival_contry", CommandSwitch.ValueMode.ExpectSingle, false ) );
            AddSwitch( new CommandSwitch( @"-type", CommandSwitch.ValueMode.ExpectSingle, false ) );
        }

        public override void Execute( CommandSwitchValues _values )
        {
            DateTime departure = DateTime.Parse( _values.GetSwitch( @"-departure" ) );
            DateTime arrivalDate = DateTime.Parse( _values.GetSwitch( @"-arrivalDate" ) );
            string airplaneNumber = _values.GetSwitch( @"-airplane_number" );
            string arrivalContry = _values.GetSwitch( @"-arrival_contry" );
            TicketType type = _values.GetSwitchAsEnum<TicketType>( @"-type" );
            using (var airlineController = ControllerFactory.CreateAirlineController())
            {
                int newTicketID = airlineController.CreateNewTicket(
                    departure,
                    arrivalDate,
                    airplaneNumber,
                    arrivalContry,
                    type );

                airlineController.AddTicket( newTicketID, getAirlineID( _values ) );
            }
        }
    }
}
