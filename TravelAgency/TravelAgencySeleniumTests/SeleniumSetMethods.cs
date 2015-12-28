using System;
using System.Collections.Generic;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TravelAgencySeleniumTests
{
    class SeleniumSetMethods
    {
        public static void enterText(
                IWebDriver _driver
            ,   string _element
            ,   string _value
            ,   string _elementType
        )
        {
            if( _elementType == "Id" )
                _driver.FindElement( By.Id( _element ) ).SendKeys( _value );
            if ( _elementType == "Name" )
                _driver.FindElement( By.Name( _element ) ).SendKeys( _value );
        }

        public static void click(
                IWebDriver _driver
            ,   string _element
            ,   string _elementType
        )
        {
            if( _elementType == "Id" )
                _driver.FindElement( By.Id( _element ) ).Click();
            if ( _elementType == "Name" )
                _driver.FindElement( By.Name( _element ) ).Click();
        }

        public static void selectDropDown(
                IWebDriver _driver
            ,   string _element
            ,   string _value
            ,   string _elementType
        )
        {
            if( _elementType == "Id" )
                new SelectElement( _driver.FindElement( By.Id( _element ) ) ).SelectByText( _value );
            if ( _elementType == "Name" )
                new SelectElement( _driver.FindElement( By.Name( _element ) ) ).SelectByText(_value);
        }

    }
}
