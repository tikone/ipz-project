using TravelAgencyModel;

using TravelAgencyOrm.Configurations;

using System.Data.Entity;

namespace TravelAgencyOrm
{
    class TravelAgencyDbContext
        :   DbContext
    {
        #region constructors

            static TravelAgencyDbContext()
            {
                Database.SetInitializer(
                    new DropCreateDatabaseIfModelChanges< TravelAgencyDbContext >()
                );
            }

        #endregion

        #region public fields

            public DbSet< Customer > Customers { get; set; }

        #endregion

        #region override

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

         #endregion
    }
}
