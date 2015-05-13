﻿using System;
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

            if (_customer.IsRegistered())
                showAccount(_customer.Account);
        }

         private void showAccount( Account _account )
        {
            output.WriteLine();
            output.WriteLine( "===Account Information===" );
            output.WriteLine( "ID: " + _account.ID );
            output.WriteLine( "Login: " + _account.Login );
            output.WriteLine( "Mail: " + _account.Mail );
            output.WriteLine( "Password hash: " + _account.PasswordHash );

            _account.History.viewHistory( showOrderedTours );
        }

        private void showOrderedTours( Tour _tour )
        {
            output.WriteLine();
            output.WriteLine("===Tour Information===");
            output.WriteLine("TourDescription: " + _tour.ViewInfo() );
            output.WriteLine("AmountPeople: " + _tour.AmountPeople);
            output.WriteLine("Country: " + _tour.Country);
            output.WriteLine("Date: " + _tour.Date_Time.ToString("d", culture) );
            output.WriteLine("Price: " + _tour.Price);
        }

        private TextWriter output;
        private TravelAgency travelAgency;
        private CultureInfo culture = new CultureInfo("pt-BR");
    }
}
