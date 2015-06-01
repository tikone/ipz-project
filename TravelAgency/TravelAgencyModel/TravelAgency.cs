using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModel
{
    public class TravelAgency
    {
        public IList< Customer > Customers{ get; private set; }

        public TravelAgency()
        {
            Customers = new List< Customer >();
        }

        public void addCustomer( Customer _customer )
        {
            Customers.Add( _customer );
        }

        public void forEachCustomer( Action< Customer > _function )
        {
            foreach( var customer in Customers )
                _function( customer );
        }
    }
}
