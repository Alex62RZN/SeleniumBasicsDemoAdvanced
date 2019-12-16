using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasicsDemo
{
    class AllProductsPage
    {
        private IWebDriver driver;

        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.AllProductPageButton = driver.FindElement(By.XPath(".//*[text()='All Products']"));
        }

        [FindsBy(How = How.XPath, Using = ".//*[text()='All Products']")]
        private IWebElement AllProductPageButton;

        public AllProductsPage AllProduct()
        {
            AllProductPageButton.Click();

            return new AllProductsPage(driver);
        }

        public bool adding()
        {
            bool isaddingSuccessfull = false;
            try
            {
                IWebElement ProductPageLabel = driver.FindElement(By.XPath(".//*[text()='All Products']"));
                isaddingSuccessfull = ProductPageLabel.Displayed;
            }
            catch (NoSuchElementException e)
            {
                isaddingSuccessfull = false;
            }
            return isaddingSuccessfull;
        }
    }
}
