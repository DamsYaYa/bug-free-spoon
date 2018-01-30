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
   public class GroupHelper : HelperBase
    {
        public GroupHelper(IWebDriver driver) : base (driver)
        {
        }
        public void CreateNewGroup()
        {
            // создание новой группы
            driver.FindElement(By.Name("new")).Click();
        }
        public void FillForm(GroupData group)
        {
            // заполнение формы
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        public void SubmitGroupCreate()
        {
            // подтверждение создания группы
            driver.FindElement(By.Name("submit")).Click();
        }
        public void RemoveSelectedGroup(int index)
        {
            // Удаление группы
            driver.FindElement(By.XPath("(//input[@name='delete'])[" + index + "]")).Click();
        }

        public void SelectGroup()
        {
            // Выбор группы
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[3]")).Click();
        }

    }
}
