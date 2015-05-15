using System;
using System.Collections.Generic;

namespace TravelAgencyModel
{
	public class TravelAgency
	{
		public TravelAgency()
		{
			customers = new List<Customer>();
		}

		public void addCustomer( Customer _customer)
		{
			customers.Add(_customer);
		}

		public void forEachCustomer( Action< Customer > _function )
		{
			foreach (var customer in customers)
				_function(customer);
		}

		private List< Customer > customers;

	}
}
