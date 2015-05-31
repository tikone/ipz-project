using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class ExcurssionConfiguration
    :   EntityTypeConfiguration< Excursion >
    {
        public ExcurssionConfiguration()
        {
            HasKey( t => t.ID );
            HasMany<Guide>(t => t.m_guides).WithRequired();
        }
    }
}
