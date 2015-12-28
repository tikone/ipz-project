using System;
using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using NUnit.Framework;

namespace TravelAgencySeleniumTests
{
    public class CreateOrderPageTests
    {
        private IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void initialize()
        {
            driver.Navigate().GoToUrl("http://localhost:63784/ManageTour/Index");
        }

        [Test]
        public void inputValues()
        {
            SeleniumSetMethods.enterText( driver, "Country", "USA", "Id" );

            SeleniumSetMethods.selectDropDown( driver, "Type", "Beer", "Id" );

            SeleniumSetMethods.enterText( driver, "Description", "some description", "Name" );

            SeleniumSetMethods.click( driver, "create_tour", "Name" );
        }

        [TearDown]
        public void cleanUp()
        {
            driver.Close();
        }
    }
}
