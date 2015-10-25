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
            HasMany< TourOrder >( a => a.History ).WithOptional();//.WithRequired();

            Property( a => a.Mail ).IsRequired();
            Property( a => a.PasswordHash ).IsRequired();
            Property( a => a.Login ).IsRequired();
        }
    }
}
