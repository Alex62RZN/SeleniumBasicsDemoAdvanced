using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;

namespace SeleniumBasicsDemo
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestMethod]
        public void Login()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:5000";

            LoginPage loginPage = new LoginPage(driver);

            Assert.IsTrue(loginPage.Login("user", "user").isLoginSuccessfull(), "Login failed");

            driver.Close();
        }

        [TestMethod]
        public void Adding()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:5000";

            LoginPage loginPage = new LoginPage(driver);

            Assert.IsTrue(loginPage.Login("user", "user").isLoginSuccessfull(), "Login failed");

            AllProductsPage allProductsPage1 = new AllProductsPage(driver);

            Assert.IsTrue(allProductsPage1.AllProduct().adding(), "Adding failed");

            Actions action = new Actions(driver);

            IWebElement CreateNew = driver.FindElement(By.XPath(".//*[text()='Create new']"));

            new Actions(driver).Click(CreateNew).Build().Perform();

            IWebElement ProductName = driver.FindElement(By.Id("ProductName"));

            new Actions(driver).Click().Click(ProductName).SendKeys("Steak").Build().Perform();

            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/select/option[7]")).Click();

            driver.FindElement(By.XPath("/html/body/div[2]/form/div[3]/div/select/option[7]")).Click();

            IWebElement UnitPrice = driver.FindElement(By.Id("UnitPrice"));

            new Actions(driver).Click().Click(UnitPrice).SendKeys("500").Build().Perform();

            IWebElement Adding = driver.FindElement(By.XPath("/html/body/div[2]/form/input[1]"));

            new Actions(driver).Click(Adding).Build().Perform();

            AllProductsPage allProductsPage = new AllProductsPage(driver);

            Assert.IsTrue(allProductsPage.adding(), "Adding Faild");

            driver.Close();
        }

        [TestMethod]
        public void Logout()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:5000";

            LoginPage loginPage = new LoginPage(driver);

            Assert.IsTrue(loginPage.Login("user", "user").isLoginSuccessfull(), "Login failed");

            LogoutPage logoutPage = new LogoutPage(driver);

            Assert.IsTrue(logoutPage.Logout().isLogoutSuccessfull(), "Logout Faild");

            driver.Close();
        }

        [TestMethod]
        public void Checking()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:5000";

            LoginPage loginPage = new LoginPage(driver);

            Assert.IsTrue(loginPage.Login("user", "user").isLoginSuccessfull(), "Login failed");

            driver.FindElement(By.XPath(".//*[text()='All Products']")).Click();

            driver.FindElement(By.LinkText("Steak")).Click();

            string name = driver.FindElement(By.Id("ProductName")).GetAttribute("value");
            Assert.AreEqual("Steak", name, "Incorrect Product name");

            string category = driver.FindElement(By.Id("CategoryId")).GetAttribute("value");
            Assert.AreEqual("6", category, "Incorrect Category Id");

            string supplier = driver.FindElement(By.Id("SupplierId")).GetAttribute("value");
            Assert.AreEqual("6", supplier, "Incorrect Supplier Id");

            string price = driver.FindElement(By.Id("UnitPrice")).GetAttribute("value");
            Assert.AreEqual("500,0000", price, "Incorrect Unit Price");

            driver.Close();
        }
    }
}
