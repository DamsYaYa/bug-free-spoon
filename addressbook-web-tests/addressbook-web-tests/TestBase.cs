using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
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

        protected void OpenHomePage()
        {
            // Открытие начальной страницы
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void Login(AccountData account)
        {
            // Логин
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        protected void OpenGroupPage()
        {
            // Переход на страницу со списком групп
            driver.FindElement(By.LinkText("groups")).Click();
        }
        protected void Logout()
        {
            // логаут
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        protected void ReturnToGroupPage()
        {
            // возвращение на страницу с группами
            driver.FindElement(By.LinkText("group page")).Click();
        }
        protected void ReturnToHomePage()
        {
            // Возвращение на стартовую страницу
            driver.FindElement(By.LinkText("group page")).Click();
        }
        protected void CreateNewGroup()
        {
            // создание новой группы
            driver.FindElement(By.Name("new")).Click();
        }
        protected void FillForm(GroupData group)
        {
            // заполнение формы
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        protected void SubmitGroupCreate()
        {
            // подтверждение создания группы
            driver.FindElement(By.Name("submit")).Click();
        }
        protected void RemoveSelectedGroup(int index)
        {
            // Удаление группы
            driver.FindElement(By.XPath("(//input[@name='delete'])[" + index + "]")).Click();
        }

        protected void SelectGroup()
        {
            // Выбор группы
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[3]")).Click();
        }
    }


}
