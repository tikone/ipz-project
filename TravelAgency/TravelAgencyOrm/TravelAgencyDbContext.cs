using TravelAgencyModel;

using TravelAgencyOrm.Configurations;

using System.Data.Entity;

namespace TravelAgencyOrm
{
    public class TravelAgencyDbContext
        :   DbContext
    {
        #region constructors

            static TravelAgencyDbContext()
            {
                Database.SetInitializer(
                    new DropCreateDatabaseAlways< TravelAgencyDbContext >()
                );
            }

        #endregion

        #region public fields

            public DbSet< Account > Accounts { get; set; }

            public DbSet< Airline > Airline { get; set; }

            public DbSet< Customer > Customers { get; set; }

            public DbSet< TourOrder > TourOrder { get; set; }

            public DbSet< Tour> Tours { get; set; }

            public DbSet< Excursion > Excursions { get; set; }

            public DbSet< Hotel > Hotels { get; set; }

            public DbSet< Room > Rooms { get; set; }

            public DbSet< Ticket > Tickets { get; set; }

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
                modelBuilder.Configurations.Add( new TourOrderConfiguration() );
            }

         #endregion
    }
}
