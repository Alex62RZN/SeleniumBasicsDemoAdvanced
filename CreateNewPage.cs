using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasicsDemo
{
    class CreateNewPage
    {

        private IWebDriver driver;

        public CreateNewPage(IWebDriver driver)
        {
            this.driver = driver;
            this.CreateButton = driver.FindElement(By.XPath(".//*[text()='Create new']"));
        }

        [FindsBy(How = How.XPath, Using = ".//*[text()='Create new']")]
        private IWebElement CreateButton;

        public CreateNewPage Create()
        {
            CreateButton.Click();

            return new CreateNewPage(driver);
        }

        public bool createpage()
        {
            bool CreatePage = false;
            try
            {
                IWebElement CreatePageLabel = driver.FindElement(By.XPath("/html/body/div[1]/h2"));
                CreatePage = CreatePageLabel.Displayed;
            }
            catch (NoSuchElementException e)
            {
                CreatePage = false;
            }
            return CreatePage;
        }
    }
}
