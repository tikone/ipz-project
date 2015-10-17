using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using TravelAgencyModel;

namespace TravelAgency.UnitsTests
{
    [TestFixture]
    class CustomerTests
    {
        #region AccountCheck

            [Test]
            public void InitiallyAccountIsNotSet()
            {
                var customer = DefaultCreator.createCustomer();

                Assert.Null( customer.Account );
            }

            [Test]
            public void AccountInitAfterCustomerRegistrated()
            {
                var customer = DefaultCreator.createRegistrateCustomer();

                Assert.NotNull( customer.Account );
            }

        #endregion

        #region Fields

            [Test]
            public void CreateCustomer()
            {
                var customer = DefaultCreator.createCustomer();

                Assert.AreEqual( customer.Name, @"Test_John" );
                Assert.AreEqual( customer.Surname, @"Test_Doe" );
            }

            [Test]
            public void EmptyNameFieldIsForbidden()
            {
                 Assert.Throws<ArgumentException>(
                   () => DefaultCreator.createCustomer( @"", @"Test_Doe" )
                 );
            }

            [Test]
            public void EmptySurnameFieldIsForbidden()
            {
                Assert.Throws<ArgumentException>(
                  () => DefaultCreator.createCustomer( @"Test_John", @"" )
                );
            }

        #endregion

        #region AddingTour

            [Test]
            public void AddingTourForRegistratedCustomer()
            {
                var customer = DefaultCreator.createRegistrateCustomer();
                var tour = DefaultCreator.createTour();

                //customer.addTour( tour );

                Assert.NotNull( customer.Account );
                Assert.IsTrue( false /*customer.Account.History.Contains( tour )*/ );

            }

        #endregion

    }   
}
