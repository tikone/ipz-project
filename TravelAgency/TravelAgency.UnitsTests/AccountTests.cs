using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using TravelAgencyModel;

namespace TravelAgency.UnitsTests
{
    [TestFixture]
    class AccountTests
    {
        #region CorrectConstructor

            [Test]
            public void CreateAccount()
            {
                var account = DefaultCreator.createAccount();

                Assert.IsNotNull( account );
                Assert.AreEqual( account.ID, 1 );
                Assert.AreEqual( account.Login, @"test_login" );
                Assert.AreEqual( account.Mail, @"test.mail@gmail.ua" );
                Assert.AreEqual( account.PasswordHash, 12345 );
            }

        #endregion

        #region CheckAddHistory

            [Test]
            public void CheckAddHistory()
            {
                var account = DefaultCreator.createAccount();
                var tourOrder = DefaultCreator.createTourOrder(
                        DefaultCreator.createTour()
                    ,   DefaultCreator.createCustomer() );

                account.AddTourOrder( tourOrder );

                Assert.True( account.History.Contains( tourOrder ) );
            }

        #endregion

        #region ValidationMail

            [Test]
            public void CorrectMail()
            {
                var airline = DefaultCreator.createAccount( @"test_login", @"name@gmail.com" );
            }

            [Test]
            public void SymbolAtMustBePresent()
            {
                Assert.Throws< ArgumentException >(
                  () => DefaultCreator.createAccount( @"test_login", @"nameAtgmail.com" )
                );
            }

            [Test]
            public void CheckDomen()
            {
                Assert.Throws< ArgumentException >(
                  () => DefaultCreator.createAccount( @"test_login", @"name@gmailDotcom" )
                );
            }

            [Test]
            public void RestrictionOnValidCharacters()
            {
                Assert.Throws<ArgumentException>(
                  () => DefaultCreator.createAccount( @"test_login", @"na!#$%^&*()+=`~/\,?><|me@gmail.com" )
                );
            }

        #endregion

        #region CheckLogin

            [Test]
            public void LoginMustBeMoreThen3Symbols()
            {
                Assert.Throws<ArgumentException>(
                  () => DefaultCreator.createAccount( @"tes" )
                );
            }

            [Test]
            public void LoginMustBeLessThen16Symbols()
            {
                Assert.Throws<ArgumentException>(
                  () => DefaultCreator.createAccount( @"testTestTestTestTest" )
                );  
            }

            [Test]
            public void VerifyLoginHaveNonWhitespaceCharacter()
            {
                Assert.Throws<ArgumentException>(
                  () => DefaultCreator.createAccount( @"lo gin" )
                );
            }

            [Test]
            public void RestrictionOnValidCharactersForLogin()
            {
                Assert.Throws<ArgumentException>(
                  () => DefaultCreator.createAccount( @"na!#$%^&*()+=`~/\,?><|me@" )
                );
            }

        #endregion

    }
}
