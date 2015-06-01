using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class HotelConfiguration
        : EntityTypeConfiguration< Hotel >
    {
        public HotelConfiguration()
        {
            HasKey( h => h.Address );
            HasMany< Room >( h => h.Rooms ).WithRequired();
        }
    }
}
