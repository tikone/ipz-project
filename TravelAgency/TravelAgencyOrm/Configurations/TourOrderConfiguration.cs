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
            HasRequired( t => t.Rooms );
            HasRequired(t => t.Tickets);
            HasRequired(t => t.m_excursions);

            Property(t => t.AmountPeople);
            Property(t => t.Date_Time);
            Property(t => t.Price);
        }
    }
}
