using System;
using System.IO;

using TravelAgencyModel;
using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class EditTourCommand : TourCommand
    {
        public EditTourCommand( TextWriter output )
            : base( "tour.edit", output )
        {
            AddSwitch( new CommandSwitch( "-country", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch( new CommandSwitch( "-description", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch( new CommandSwitch( "-type", CommandSwitch.ValueMode.ExpectSingle, true ) );
        }

        public override void Execute( CommandSwitchValues _values )
        {
            int tourID = GetTourID( _values );
            using (var manageTourController = ControllerFactory.CreateManageTourController())
            {
                string country = _values.GetOptionalSwitch( "-country" );
                if( country != null )
                    manageTourController.UpdateCountry( tourID, country );

                string description = _values.GetOptionalSwitch( "-description" );
                if( description != null )
                    manageTourController.UpdateDescription( tourID, description );

                if( _values.GetOptionalSwitch( "-type" ) != null )
                    manageTourController.UpdateType( tourID, _values.GetSwitchAsEnum< TourType >( "-type" ) );
            }
        }
    }
}