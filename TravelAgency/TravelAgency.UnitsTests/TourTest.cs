using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace TravelAgency.UnitsTests
{

    [ TestFixture ]
    class TourTest
    {
        //[ Test ]
        //public void CreateTour()
        //{
        //    var tour = DefaultCreator.createTour();
        //
        //}

        #region AddExcursion

            [ Test ]
            public void AddExcursion_AddOneExcursion()
            {
                var tour = DefaultCreator.createTour();

                var excursion =
                    DefaultCreator.createExursion(
                        DefaultCreator.createDateTime()
                    );

                tour.AddExcursion(
                    excursion
                );

                Assert.IsTrue( tour.GetExcursion().Contains( excursion ) );

            }

        #endregion

        #region AddHotel

            [Test, Ignore]
            public void addHotel()
            {
                var hotel = DefaultCreator.createHotel();

                var tour = DefaultCreator.createTour( 322, 2, hotel );

                Assert.AreSame( tour.Hotel, hotel );
            }

        #endregion
    }
}
