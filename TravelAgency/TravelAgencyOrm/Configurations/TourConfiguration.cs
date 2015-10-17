using TravelAgencyModel;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm.Configurations
{
    class TourConfiguration
        :   EntityTypeConfiguration< Tour >
    {
        public TourConfiguration()
        {
            HasKey( t => t.TourID );
            //HasRequired( t => t.Hotel );
            //HasRequired( t => t.Airline );
            //HasMany< Excursion >( t => t.m_excursions ).WithOptional();

            //Property( t => t.AmountPeople ).IsRequired();
            Property( t => t.Country ).IsRequired();
            //Property( t => t.Date_Time ).IsRequired();
            //Property( t => t.Price ).IsRequired();
        }
    }
}
