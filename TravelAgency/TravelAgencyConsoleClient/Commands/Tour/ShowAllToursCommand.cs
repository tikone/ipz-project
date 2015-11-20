using System;
using System.IO;

using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class ShowAllToursCommand : Command
    {
        public ShowAllToursCommand( TextWriter output )
            : base( "tour.showall", output )
        {
        }

        public override void Execute( CommandSwitchValues values )
        {
            using (var manageTourController = ControllerFactory.CreateManageTourController() )
            {
                var tours = manageTourController.ViewAllTours();
                ReportValues( tours );
            }
        }
    }
}