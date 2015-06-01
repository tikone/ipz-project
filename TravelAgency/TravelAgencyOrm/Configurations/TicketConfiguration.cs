using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class TicketConfiguration
        : EntityTypeConfiguration< Ticket >
    {
        public TicketConfiguration()
        {
            HasKey( t => t.TicketID );

            Property( t => t.ArrivalCountry ).IsRequired();
            Property( t => t.ArrivalDate ).IsRequired();
            Property( t => t.Departure ).IsRequired();
            Property( t => t.NumberOfAirplane ).IsRequired();
        }
    }
}
