using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using TravelAgencyModel;

namespace TravelAgency.UnitsTests
{
    [TestFixture]
    class AirlineTests
    {
        #region CheckTicket

            [Test]
            public void CheckNotRegistratedTicket()
            {
                var airline = DefaultCreator.createAirline( 0 );
                var depart = DefaultCreator.createDateTime( 2000, 2, 2 );
                var arrive = DefaultCreator.createDateTime( 2200, 2, 2 );
                var ticket = DefaultCreator.createTicket( depart, arrive );

                Assert.Throws<Exception>(
                  () => airline.CheckTicket( ticket )
                );
            }

            [Test]
            public void CheckRegistratedTicket()
            {
                var airline = DefaultCreator.createAirline( 0 );
                var depart = DefaultCreator.createDateTime( 2000, 2, 2 );
                var arrive = DefaultCreator.createDateTime( 2200, 2, 2 );
                var ticket = DefaultCreator.createTicket( depart, arrive );
                airline.AddTicket( ticket );

                Assert.False( airline.CheckTicket(ticket) );
            }

        #endregion

        #region GetAvailableTicket

            [Test]
            public void GetUnreservedTickets()
            {
                var airline = DefaultCreator.createAirline( 0 );
                var depart = DefaultCreator.createDateTime( 2000, 2, 2 );
                var arrive = DefaultCreator.createDateTime( 2200, 2, 2 );
                var ticket = DefaultCreator.createTicket( depart, arrive );
                var ticket2 = DefaultCreator.createTicket( depart, arrive );
                ticket2.Reserved = true;

                airline.AddTicket( ticket );
                airline.AddTicket( ticket2 );

                var unreservedTicketCollection = airline.GetAvailableTickets();

                Assert.True( unreservedTicketCollection.Count == 1 );
                Assert.True( unreservedTicketCollection.Contains( ticket ) );
            }

        #endregion

        #region Fields

            [Test]
            public void CreateAirline()
            {
                var airline = DefaultCreator.createAirline();

                Assert.AreEqual( airline.Name, @"test_airline" );
            }

            [Test]
            public void EmptyNameFieldIsForbidden()
            {
                Assert.Throws<ArgumentException>(
                  () => DefaultCreator.createAirline( 1, @"" )
                );
            }

        #endregion

    }
}
