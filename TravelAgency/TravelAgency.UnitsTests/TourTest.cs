using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using TravelAgencyModel;

using NSubstitute;

namespace TravelAgency.UnitsTests
{

    [ TestFixture ]
    class TourTest
    {

        #region Fields

            [Test]
            public void CheckCountry()
            {
                var tour = DefaultCreator.createTour();

                Assert.AreSame( tour.Country, @"UA" );
            }

            [Test]
            public void EmptyCountryFieldIsForbidden()
            {
                Assert.Throws<ArgumentException>(
                   () => DefaultCreator.createTour( @"", @"description" )
               );

            }

            [Test]
            public void Description()
            {
                var tour = DefaultCreator.createTour();

                Assert.AreEqual( @"description", tour.Description );
            }


        #endregion
    }
}
