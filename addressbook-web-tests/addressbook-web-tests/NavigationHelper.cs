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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) : base (driver)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            // Открытие начальной страницы
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void ReturnToHomePage()
        {
            // Возвращение на страницу со списком групп
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void OpenGroupPage()
        {
            // Переход на страницу со списком групп
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToGroupPage()
        {
            // возвращение на страницу с группами
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToHomePage()
        {
            // Переход на страницу со списком контактов
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
