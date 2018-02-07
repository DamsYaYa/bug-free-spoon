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
   public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base (manager)
        {
        }


        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
        public void Logout()
        {
            // логаут
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
