using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasicsDemo
{
    class LogoutPage
    {

        private IWebDriver driver;


        public LogoutPage(IWebDriver driver)
        {
            this.driver = driver;
            this.logoutbutton = driver.FindElement(By.LinkText("Logout"));
        }

        [FindsBy(How = How.LinkText, Using = "Logout")]
        private IWebElement logoutbutton;

        public LogOutPagee Logout()
        {
            logoutbutton.Click();

            return new LogOutPagee(driver);
        }
        
    }
}