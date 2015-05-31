using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class AirlineConfiguration
    :   EntityTypeConfiguration< Airline >
    {
        public AirlineConfiguration()
        {
            HasKey( t => t.ID );
            HasMany< Ticket >( t => t.m_tickets ).WithRequired();
        }
    }
}
