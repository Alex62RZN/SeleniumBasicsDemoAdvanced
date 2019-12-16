using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace SeleniumBasicsDemo
{

    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.loginField = driver.FindElement(By.Id("Name"));
            this.passwordField = driver.FindElement(By.Id("Password"));
        }

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement loginField;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordField;

        public MainPage Login(String login, String passwod)
        {
            loginField.SendKeys(login);
            passwordField.SendKeys(passwod);
            passwordField.Submit();

            return new MainPage(driver);
        }
    }
}
