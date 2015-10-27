using System;
using System.IO;

using TravelAgencyModel;

namespace TravelAgencyDemoApp
{
    class ReportGenerator
    {
        public ReportGenerator( TextWriter _output )
        {
            output = _output;
        }

        public void ShowCustomer( Customer _customer )
        {
            output.WriteLine( "==== Customers ====" );
            output.WriteLine("ID: " + _customer.ID);
            output.WriteLine( "Name: " + _customer.Name );
            output.WriteLine( "Surname: " + _customer.Surname );

            if( _customer.IsRegistered() ) 
                ShowAccount( _customer.Account );
        }

        public void ShowAccount( Account _account )
        {
            output.WriteLine();
            output.WriteLine( "===Account Information===" );
            output.WriteLine( "ID: " + _account.ID );
            output.WriteLine( "Login: " + _account.Login );
            output.WriteLine( "Mail: " + _account.Mail );
            output.WriteLine( "Password hash: " + _account.PasswordHash );

            output.WriteLine();
            output.WriteLine( "===History===" );
            foreach (var tour in _account.History)
                ShowTourOrder(tour);

            output.WriteLine("\n***End History************************\n");
        }

        public void ShowTourOrder(TourOrder _tourOrder)
        {
            output.WriteLine();
            output.WriteLine("===TourOrder===");
            output.WriteLine("AmountPeople: " + _tourOrder.AmountPeople);
            output.WriteLine("Date: " + _tourOrder.Date_Time.ToString("d"));
            output.WriteLine("Price: " + _tourOrder.Price);

            ShowTour(_tourOrder.Tour);

            foreach (var excursion in _tourOrder.GetExcursion() )
                ShowExcursion(excursion);

            foreach (var room in _tourOrder.Rooms)
                output.WriteLine( room );

            foreach (var ticket in _tourOrder.Tickets)
                output.WriteLine(ticket);



            output.WriteLine("\n***End TourOrder************************\n");
        }

        public void ShowTour(Tour _tour)
        {
            output.WriteLine();
            output.WriteLine("===Tour===");
            output.WriteLine("TourID: " + _tour.TourID);
            output.WriteLine("Country: " + _tour.Country);
            output.WriteLine("Description: " + _tour.Description);

            output.WriteLine("Type: " + _tour.Type);


            output.WriteLine("\n***End Tour************************\n");
        }

        public void ShowExcursion(Excursion _excursion)
        {
            output.WriteLine();
            output.WriteLine("===Excursion===");
            output.WriteLine("ID: " + _excursion.ExcursionID);
            output.WriteLine("Date: " + _excursion.Date_Time.ToString("d"));

            foreach (var guide in _excursion.Guides)
                ShowGuide(guide);

            output.WriteLine("\n***End Excursion************************\n");
        }

        public void ShowGuide(Guide _guide)
        {
            output.WriteLine();
            output.WriteLine("===Guide===");
            output.WriteLine("Name: " + _guide.Name);
            output.WriteLine("Phone: " + _guide.Phone);
            output.WriteLine("Available: " + _guide.Available);

            output.Write("Languages:");
            foreach( var lang in _guide.Languages )
                output.Write( lang );

            output.WriteLine("\n***End Guide************************\n");
        }

        public void ShowRoom(Room _room)
        {
            output.WriteLine();
            output.WriteLine("===Room===");
            output.WriteLine("Number: " + _room.Number);
            output.WriteLine("Reserved: " + _room.Reserved);
            output.WriteLine("TypeOfRoom: " + _room.TypeOfRoom);
            output.WriteLine("TypeOfBeds: " + _room.TypeOfBeds);

            output.WriteLine("\n***End Room************************\n");
        }

        public void ShowHotel( Hotel _hotel)
        {
            output.WriteLine();
            output.WriteLine( "===Hotel Information===" );
            output.WriteLine( "Name: " + _hotel.Name );
            output.WriteLine( "Address: "+ _hotel.Address );
            output.WriteLine( "HotelType: "+ _hotel.Type );
        }

        public TextWriter output;
    }
}
