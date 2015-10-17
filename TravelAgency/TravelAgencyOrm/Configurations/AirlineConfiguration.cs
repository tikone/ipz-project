using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class AirlineConfiguration
        : EntityTypeConfiguration< Airline >
    {
        public AirlineConfiguration()
        {
            HasKey( a => a.AirlineID );
            HasMany<Ticket>(a => a.Tickets).WithRequired();
            Property( a => a.Name ).IsRequired();
        }
    }
}
