using System;
using System.Text;

using TravelAgencyModel;
using TravelAgency.Infrastructure;

namespace TravelAgencyController.Notifier
{
    class EmailNotifier
    {
        public EmailNotifier( IEmailAgent _emailAgent )
        {
            this.emailAgent = _emailAgent;
        }

        public void SendOrderRegistered( TourOrder _order )
        {
            var builder = new StringBuilder();
            builder.Append( "Your tour order #" );
            builder.Append( _order.TourOrderID );
            builder.Append( " was registered." );
            builder.Append( " Total amount: $" );
            builder.Append( _order.Price );

            emailAgent.sendEmail(
                _order.Customer.Name,
                "Tour order registered",
                builder.ToString()
            );
        }

        public void SendDateChanged( TourOrder _order )
        {
            var builder = new StringBuilder();
            builder.Append( "For tour order #" );
            builder.Append( _order.TourOrderID );
            builder.Append( " date was changed." );
            builder.Append( " New time: " );
            builder.Append( _order.Date_Time.ToString() );

            emailAgent.sendEmail(
                _order.Customer.Name,
                "Tour date changed",
                builder.ToString()
            );

            emailAgent.sendEmail(
                OperatorEmail,
                "Tour date changed",
                builder.ToString()
            );
        }

        public void SendOrderCancelled( TourOrder _order )
        {
            var builder = new StringBuilder();
            builder.Append( "Order #" );
            builder.Append( _order.TourOrderID );
            builder.Append( " was cancelled.");

            emailAgent.sendEmail(
                OperatorEmail,
                "Tour cancelled",   
                builder.ToString()
            );

            emailAgent.sendEmail(
                _order.Customer.Name,
                "Tour cancelled",
                builder.ToString()
            );
        }

        public void SendNewTourCreated( Tour _tour )
        {
            var builder = new StringBuilder();
            builder.Append( "Tour #" );
            builder.Append( _tour.TourID );
            builder.Append( " .With description: \"" );
            builder.Append( _tour.Description );
            builder.Append( "\" was succesfully added to base. " );

            emailAgent.sendEmail(
                OperatorEmail,
                "New tour created",
                builder.ToString()
            );
        }

        public void SendCountryForTourUpdated( Tour _tour )
        {
            var builder = new StringBuilder();
            builder.Append( "Tour #" );
            builder.Append( _tour.TourID );
            builder.Append(" .Was set new country: \"");
            builder.Append( _tour.Country );
            builder.Append("\" succesfully. ");

            emailAgent.sendEmail(
                OperatorEmail,
                "Tour country updated",
                builder.ToString()
            );
        }

        public void SendDescriptionForTourUpdated( Tour _tour )
        {
            var builder = new StringBuilder();
            builder.Append( "Tour #" );
            builder.Append( _tour.TourID );
            builder.Append( " .Was set new description: \"" );
            builder.Append( _tour.Description );
            builder.Append("\" succesfully. ");

            emailAgent.sendEmail(
                OperatorEmail,
                "Tour description updated",
                builder.ToString()
            );
        }

        private IEmailAgent emailAgent;

        private static readonly string OperatorEmail = "operator@travelAgency.com";
        private static readonly string AdministratorEmail = "administrator@travelAgency.com";
    }
}