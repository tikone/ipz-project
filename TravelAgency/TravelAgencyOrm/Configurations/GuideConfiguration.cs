using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class GuideConfiguration
        : EntityTypeConfiguration< Guide >
    {
        public GuideConfiguration()
        {
            HasKey( g => g.Phone );

            Property( g => g.Name ).IsRequired();
        }
    }
}
