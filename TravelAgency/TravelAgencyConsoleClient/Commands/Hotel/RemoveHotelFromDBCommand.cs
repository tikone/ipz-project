using System;
using System.IO;

using TravelAgencyController.Controller;

namespace TravelAgencyConsoleClient
{
    class RemoveHoteFromDBCommand : HotelCommand
    {
        public RemoveHoteFromDBCommand( TextWriter _output )
            : base( @"hotel.database.remove", _output )
        {
        }

        public override void Execute( CommandSwitchValues _values )
        {
            using( var hotelController = ControllerFactory.CreateHotelController() )
            {
                hotelController.RemoveHotelFromDB( getHotelID( _values ) );
            }
        }
    }
}
