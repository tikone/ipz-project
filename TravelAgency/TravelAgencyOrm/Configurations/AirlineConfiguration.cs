using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class AirlineConfiguration
        : EntityTypeConfiguration< Airline >
    {
        public AirlineConfiguration()
        {
            HasKey( airline => airline.ID );
            HasMany<Ticket>(airline => airline.Tickets);
            Property( airline => airline.Name ).IsRequired();
        }
    }
}
