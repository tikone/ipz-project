using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace TravelAgencyModel
{
    public class ModelReporter
    {
        public ModelReporter( TextWriter _output, TravelAgency _travelAgency )
        {
            output = _output;
            travelAgency = _travelAgency;
        }

        public void generate()
        {
            travelAgency.forEachCustomer(showCustomer);
        }

        private void showCustomer( Customer _customer )
        {
            output.WriteLine( "==== Customers ====" );
            output.WriteLine( "Name: " + _customer.Name );
            output.WriteLine( "Surname: " + _customer.Surname );
        }

         private void showAccount( Account _account )
        {
            output.WriteLine();
            output.WriteLine( "\tAccount Information" );
            output.WriteLine( "\t\tID: " + _account.ID );
            output.WriteLine( "\t\tLogin: " + _account.Login );
            output.WriteLine( "\t\tMail: " + _account.Mail );
            output.WriteLine( "\t\tPassword hash: " + _account.PasswordHash );

            _account.History.viewHistory( showOrderedTours );
        }

        private void showOrderedTours( Tour _tour )
        {
            output.WriteLine();
            CultureInfo culture = new CultureInfo("pt-BR");
            output.WriteLine("\t\tTour Information");
            output.WriteLine("\t\t\tTourDescription: " + _tour.ViewInfo() );
            output.WriteLine("\t\t\tAmountPeople: " + _tour.AmountPeople);
            output.WriteLine("\t\t\tCountry: " + _tour.Country);
            output.WriteLine("\t\t\tDate: " + _tour.Date_Time.ToString("d", culture) );
            output.WriteLine("\t\t\tPrice: " + _tour.Price);
        }

        private TextWriter output;
        private TravelAgency travelAgency;
    }
}
