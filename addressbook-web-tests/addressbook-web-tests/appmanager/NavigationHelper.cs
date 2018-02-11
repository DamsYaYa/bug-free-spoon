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

        public NavigationHelper(ApplicationManager manager, string baseURL) : base (manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            // Открытие начальной страницы
            if(driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }
        public void OpenGroupPage()
        {
            // Переход на страницу со списком групп
            if(driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToHomePage()
        {
            // Переход на страницу со списком контактов
            if (driver.Url == baseURL + "/addressbook/"
                 && IsElementPresent(By.XPath("//input[@value='Send e-Mail']")))
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
