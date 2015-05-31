using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class TourConfiguration
        :   EntityTypeConfiguration< Tour >
    {
        public TourConfiguration()
        {

        }
    }
}
