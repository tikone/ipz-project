using System;
using System.IO;

using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class AirlineTicketShowCommand : Command
    {
        public AirlineTicketShowCommand( TextWriter output )
            : base( @"airline.ticket.show", output )
        {
            AddSwitch( new CommandSwitch( @"-id", CommandSwitch.ValueMode.ExpectSingle, true ) );
        }

        public override void Execute( CommandSwitchValues _values )
        {
            string airlineID = _values.GetOptionalSwitch( @"-id" );
            using( var airlineController = ControllerFactory.CreateAirlineController() )
            {
                var airlinesView = airlineController.ViewAllAirlines();
                if (airlineID == null )
                {
                    ReportValues( airlineController.ViewAllTickets() );
                    return;
                }

                foreach( var view in airlinesView )
                    if( view.AirlineID.ToString() == airlineID )
                    {
                        ReportValues(view.Tickets);
                        break;
                    }
            }
        }
    }
}
