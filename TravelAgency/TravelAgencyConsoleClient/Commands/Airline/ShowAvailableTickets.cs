using System;
using System.IO;
using System.Collections.Generic;

using TravelAgencyController.Controller;
using TravelAgencyController.ViewModel;

namespace TravelAgencyConsoleClient
{
    class ShowAvailableTickets : AirlineCommand
    {
        public ShowAvailableTickets( TextWriter output )
            : base(@"airline.ticket.show.available", output)
        {
        }

        public override void Execute(CommandSwitchValues _values)
        {
            int airlineID = getAirlineID(_values);
            using( var airlineController = ControllerFactory.CreateAirlineController() )
            {
                var airlinesView = airlineController.ViewAllAirlines();
                foreach( var view in airlinesView )
                    if( view.AirlineID == airlineID )
                    {
                        List< TicketView > res = new List< TicketView >();
                        foreach( var ticket in view.Tickets )
                            if( !ticket.Reserved )
                                res.Add( ticket );
                        ReportValues( res );
                        break;
                    }
            }
        }
    }
}
