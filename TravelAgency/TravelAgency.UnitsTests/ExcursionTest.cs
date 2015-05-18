using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace TravelAgency.UnitsTests
{
    class ExcursionTest
    {
        #region Fields

            [Test]
            public void CreateExcursion()
            {
                var excursion =
                    DefaultCreator.createExursion( DefaultCreator.createDateTime() );

                Assert.IsNotNull( excursion );
            }

            [Test]
            public void EmptyNameFieldIsForbidden()
            {
                Assert.Throws< ArgumentNullException >(
                    () =>
                    {
                        new TravelAgencyModel.Excursion(
                                @""
                            ,   322
                            ,   DefaultCreator.createDateTime()
                        );
                    }
                );
            }

            [Test]
            public void AddGuide()
            {
                var excursion =
                    DefaultCreator.createExursion(DefaultCreator.createDateTime());

                var guide = DefaultCreator.createGuide();

                excursion.addGuide( guide );

                Assert.IsNotEmpty( excursion.getAvailableGuides() );
                Assert.AreEqual( guide, excursion.getAvailableGuides()[ 0 ] );

            }

            [Test]
            public void TwiceAddOneGuide()
            {
                var excursion =
                    DefaultCreator.createExursion(DefaultCreator.createDateTime());

                var guide = DefaultCreator.createGuide();

                excursion.addGuide( guide );

                Assert.IsNotEmpty(excursion.getAvailableGuides());
                Assert.Throws< Exception >(
                    () => excursion.addGuide( guide )
                );

            }

            [ Test ]
            public void CheckGetAvailableLanguages()
            {
                var excursion =
                    DefaultCreator.createExursion(DefaultCreator.createDateTime());

                var language = @"Ukranian";

                var guide = DefaultCreator.createGuide( language );

                excursion.addGuide(guide);

                Assert.IsTrue( excursion.getAvailableLanguages().Contains( language ) );

            }

        #endregion
    }
}
