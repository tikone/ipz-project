using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModel
{
    class TravelAgency
    {
        public TravelAgency()
        {
            customers = new List<Customer>();
        }

        public void AddCustomer( Customer _customer)
        {
            customers.Add(_customer);
        }

        public void ForEachCustomer( Action< Customer > _function )
        {
            foreach (var customer in customers)
                _function(customer);
        }

        private List< Customer > customers;

    }
}
