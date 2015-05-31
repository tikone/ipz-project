using TravelAgencyModel;

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
            // TODO: build model with configuration
            // modelBuilder.Configurations.Add( new PizzaRecipeConfiguration() );
        }
    }
}
