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
        public GroupHelper(ApplicationManager manager) : base (manager)
        {
        }
        public GroupHelper CreateGroup (GroupData group)
        {
            manager.Navigator.OpenGroupPage();
            CreateNewGroup();
            FillForm(group);
            SubmitGroupCreate();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newGroupData)
        {
            manager.Navigator.OpenGroupPage();

            SelectGroup();
            InitGroupModification();
            FillForm(newGroupData);
            SubmitGroupModification();
           
            return this;
        }

        public GroupHelper RemoveGroup(int v)
        {
            manager.Navigator.OpenGroupPage();

            SelectGroup();
            RemoveSelectedGroup(v);
            manager.Navigator.OpenGroupPage();
            return this;
        }


        public GroupHelper CreateNewGroup()
        {
            // создание новой группы
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillForm(GroupData group)
        {
            // заполнение формы
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }
        public GroupHelper SubmitGroupCreate()
        {
            // подтверждение создания группы
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper RemoveSelectedGroup(int index)
        {
            // Удаление группы
            driver.FindElement(By.XPath("(//input[@name='delete'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroup()
        {
            // Выбор группы
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[3]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
