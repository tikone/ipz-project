using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class TourConfiguration
        :   EntityTypeConfiguration< Tour >
    {
        public TourConfiguration()
        {
            HasKey( t => t.TourID );
            HasRequired( t => t.Hotel );
            HasRequired( t => t.Airline );
            HasMany< Excursion >( t => t.GetExcursion() ).WithRequired();
            HasMany< Ticket >( t => t.Tickets ).WithRequired();
            HasMany< Room >( t => t.Rooms ).WithRequired();
        }
    }
}
