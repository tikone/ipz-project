using System;
using System.IO;

using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class ShowToursCommand : Command
    {
        public ShowToursCommand( TextWriter output )
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