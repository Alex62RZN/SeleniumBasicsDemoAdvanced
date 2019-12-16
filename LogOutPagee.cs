using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasicsDemo
{
    class LogOutPagee
    {
        private IWebDriver driver;

        public LogOutPagee(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool isLogoutSuccessfull()
        {
            bool isLogoutSuccessfull = false;
            try
            {
                IWebElement LoginPageLabel = driver.FindElement(By.XPath(".//*[text()='Login']"));
                isLogoutSuccessfull = LoginPageLabel.Displayed;
            }
            catch (NoSuchElementException e)
            {
                isLogoutSuccessfull = false;
            }
            return isLogoutSuccessfull;
        }
    }
}
