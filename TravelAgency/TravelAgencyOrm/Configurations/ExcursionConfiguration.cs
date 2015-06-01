using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class ExcursionConfiguration
        : EntityTypeConfiguration< Excursion >
    {
        public ExcursionConfiguration()
        {
            HasKey( e => e.ExcursionID );
            HasMany< Guide >( e => e.Guides );

            Property( g => g.Name ).IsRequired();
            Property( g => g.Price ).IsRequired();
            Property( g => g.Date_Time ).IsRequired();
        }
    }
}
