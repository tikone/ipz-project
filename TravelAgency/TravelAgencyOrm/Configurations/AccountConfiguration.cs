using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class AccountConfiguration
    :   EntityTypeConfiguration< Account >
    {
        public AccountConfiguration()
        {
            HasKey( t => t.ID );
            HasMany< Tour >( t => t.History).WithRequired();
        }
    }
}
