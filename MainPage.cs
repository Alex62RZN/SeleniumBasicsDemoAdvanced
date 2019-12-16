using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasicsDemo
{
    class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool isLoginSuccessfull()
        {
            bool isLoginSuccessfull = false;
            try
            {
                IWebElement homePageLabel = driver.FindElement(By.XPath(".//*[text()='Home page']"));
                isLoginSuccessfull = homePageLabel.Displayed;
            }
            catch (NoSuchElementException e)
            {
                isLoginSuccessfull = false;
            }
            return isLoginSuccessfull;
        }
    }
}