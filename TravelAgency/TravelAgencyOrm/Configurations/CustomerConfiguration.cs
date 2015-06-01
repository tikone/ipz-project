using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class CustomerConfiguration
        : EntityTypeConfiguration< Customer >
    {
        public CustomerConfiguration()
        {
            HasKey( c => c.CustomerID );
            HasOptional< Account >( c => c.Account );

            Property( c => c.Name ).IsRequired();
            Property( c => c.Surname ).IsRequired();
        }
    }
}
