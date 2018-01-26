using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroup
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            // FirefoxOptions options = new FirefoxOptions();
            // options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            // options.UseLegacyImplementation = true;
            //  driver = new FirefoxDriver(options);
            driver = new ChromeDriver();
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void CreatorGroupsTest()
        {
            OpenHomePage();
            Login("admin", "secret");
            OpenGroupPage();
            CreateNewGroup();
            FillForm("aaa", "bbb", "ccc");
            SubmitGroupCreate();
            ReturnToGroupPage();
            Logout();
        }

        private void Logout()
        {
            // логаут
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnToGroupPage()
        {
            // возвращение на страницу с группами
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SubmitGroupCreate()
        {
            // подтверждение создания группы
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillForm(string name, string header, string footer)
        {
            // заполнение формы
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(footer);
        }

        private void CreateNewGroup()
        {
            // создание новой группы
            driver.FindElement(By.Name("new")).Click();
        }

        private void OpenGroupPage()
        {
            // переход на страницу со списком групп
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login(string username, string password)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }


        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/group.php");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

