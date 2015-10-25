using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class TourOrderConfiguration
        : EntityTypeConfiguration<TourOrder>
    {
        public TourOrderConfiguration()
        {
            HasKey(t => t.TourOrderID);
            HasRequired( t => t.Tour );
            HasMany<Room>(t => t.Rooms).WithOptional();
            HasMany<Ticket>(t => t.Tickets).WithOptional();
            HasMany<Excursion>(t => t.m_excursions).WithOptional();

            Property(t => t.AmountPeople);
            Property(t => t.Date_Time);
            Property(t => t.Price);
        }
    }
}
