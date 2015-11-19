using System;
using System.IO;

using TravelAgencyModel;
using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class CreateTourCommand : Command
    {
        public CreateTourCommand( TextWriter output )
            : base( "tour.create", output )
        {
            AddSwitch( new CommandSwitch( "-country", CommandSwitch.ValueMode.ExpectSingle, false ) );
            AddSwitch( new CommandSwitch( "-description", CommandSwitch.ValueMode.ExpectSingle, true) );
            AddSwitch( new CommandSwitch( "-type", CommandSwitch.ValueMode.ExpectSingle, false) );
        }

        public override void Execute( CommandSwitchValues values )
        {
            string country = values.GetSwitch( "-country" );

            string description = values.GetOptionalSwitch( "-description" );
            if (description == null)
                description = "";

            using (var manageTourController = ControllerFactory.CreateManageTourController() )
            {
                manageTourController.CreateNewTour(
                        country
                    ,   description
                    ,   values.GetSwitchAsEnum< TourType >( "-type" )
               );
            }
        }
    }
}