using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class AccountConfiguration
        : EntityTypeConfiguration< Account >
    {
        public AccountConfiguration()
        {
            HasKey( a => a.ID );
            HasMany< Tour >( a => a.History ).WithRequired();

            Property( a => a.Mail ).IsRequired();
            Property( a => a.PasswordHash ).IsRequired();
            Property( a => a.Login ).IsRequired();
        }
    }
}
