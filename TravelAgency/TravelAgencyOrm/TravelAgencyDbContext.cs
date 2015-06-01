using TravelAgencyModel;

using TravelAgencyOrm.Configurations;

using System.Data.Entity;

namespace TravelAgencyOrm
{
    class TravelAgencyDbContext
        :   DbContext
    {
        static TravelAgencyDbContext()
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges< TravelAgencyDbContext >()
            );
        }

        //TODO: add properties gateways DbSet


        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Configurations.Add( new AccountConfiguration() );
            modelBuilder.Configurations.Add( new AirlineConfiguration() );
            modelBuilder.Configurations.Add( new CustomerConfiguration() );
            modelBuilder.Configurations.Add( new ExcursionConfiguration() );
            modelBuilder.Configurations.Add( new GuideConfiguration() );
            modelBuilder.Configurations.Add( new HotelConfiguration() );
            modelBuilder.Configurations.Add( new RoomConfiguration() );
            modelBuilder.Configurations.Add( new TicketConfiguration() );
            modelBuilder.Configurations.Add( new TourConfiguration() );
        }
    }
}
