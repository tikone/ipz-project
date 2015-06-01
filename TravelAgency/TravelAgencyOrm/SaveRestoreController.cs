using TravelAgencyModel;

using System.Data.Entity;

using System.Data.Entity.ModelConfiguration;

namespace TravelAgencyOrm
{
    public class SaveRestoreController
    {
        public static void Save( TravelAgency _travelAgency )
        {
            using ( var context = new TravelAgencyDbContext() )
            {
                context.Database.Delete();
                context.Customers.AddRange( _travelAgency.Customers );
                context.SaveChanges();
            }
        }

        public static TravelAgency Restore()
        {
            TravelAgency travelAgency = new TravelAgency();

            using( var context = new TravelAgencyDbContext() )
            {
                var customerQuery =
                    context.Customers.Include( c => c.Account );

                foreach( Customer customer in customerQuery )
                    travelAgency.addCustomer( customer );
            }

            return travelAgency;
        }
    }
}
