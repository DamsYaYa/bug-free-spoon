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

        public GroupHelper Modify(GroupData newGroupData)
        {
            manager.Navigator.OpenGroupPage();

            SelectGroup();
            InitGroupModification();
            FillForm(newGroupData);
            SubmitGroupModification();
           
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            manager.Navigator.OpenGroupPage();

            SelectGroup();
            RemoveSelectedGroup(1);
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
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
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
