using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class CustomerConfiguration
    :   EntityTypeConfiguration< Customer >
    {
        public CustomerConfiguration()
        {
            HasKey( t => t.ID );
            HasRequired< Account >( t => t.Account );
        }
    }
}
