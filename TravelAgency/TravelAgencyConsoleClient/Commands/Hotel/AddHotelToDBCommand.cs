using System;
using System.IO;
using System.Collections.Generic;

using TravelAgencyModel;
using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class AddHotelToDBCommand : Command
    {
        public AddHotelToDBCommand( TextWriter _output )
            : base( @"hotel.database.add", _output )
        {
            AddSwitch( new CommandSwitch( @"-name", CommandSwitch.ValueMode.ExpectSingle, false ) );
            AddSwitch( new CommandSwitch( @"-adress", CommandSwitch.ValueMode.ExpectSingle, false ) );
            AddSwitch( new CommandSwitch( @"-type", CommandSwitch.ValueMode.ExpectSingle, false ) );
        }

        public override void Execute(CommandSwitchValues _values)
        {
            using( var hotelController = ControllerFactory.CreateHotelController() )
            {
                hotelController.AddNewHotelToDB(
                    _values.GetSwitch( @"-name" ),
                    _values.GetSwitch( @"-adress" ),
                    _values.GetSwitchAsEnum< HotelType >( @"-type" ),
                    new HashSet< Room >()
                );
            }
        }
    }
}
