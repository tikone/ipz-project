using System;
using System.IO;
using System.Collections.Generic;

using TravelAgencyController.Controller;
using TravelAgencyController.ViewModel;

namespace TravelAgencyConsoleClient
{
    class ShowHotelCommand : Command
    {
        public ShowHotelCommand( TextWriter _output )
            : base( @"hotel.show", _output )
        {
            AddSwitch( new CommandSwitch( @"-id", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch( new CommandSwitch( @"-name", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch( new CommandSwitch( @"-adress", CommandSwitch.ValueMode.ExpectSingle, true ) );
            AddSwitch( new CommandSwitch( @"-type", CommandSwitch.ValueMode.ExpectSingle, true ) );
        }

        public override void Execute(CommandSwitchValues _values)
        {
            using( var hotelController = ControllerFactory.CreateHotelController() )
            {
                List< HotelView > result = new List< HotelView >();
                var hotelsView = hotelController.ViewAllHotels();
                foreach(var view in hotelsView )
                    if( shouldAddHotel( _values, view ) )
                        result.Add( view );

                ReportValues(result);
            }
        }

        private bool shouldAddHotel( CommandSwitchValues _values, HotelView _hotelView )
        {
            string hotelID = _values.GetOptionalSwitch( @"-id" );
            if( hotelID != null && _hotelView.HotelId.ToString() != hotelID )
                return false;

            string name = _values.GetOptionalSwitch( @"-name" );
            if( name != null && _hotelView.Name != name )
                return false;

            string adress = _values.GetOptionalSwitch( @"-adress" );
            if( adress != null && _hotelView.Address != adress )
                return false;

            string type = _values.GetOptionalSwitch( @"-type" );
            if( type != null && _hotelView.HotelType.ToString() != type )
                return false;

            return true;
        }
    }
}