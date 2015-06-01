using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class RoomConfiguration
        : EntityTypeConfiguration< Room >
    {
        public RoomConfiguration()
        {
            HasKey( r => r.Number );

            Property( r => r.BedNumber ).IsRequired();
            Property( r => r.TypeOfRoom ).IsRequired();
        }
    }
}
