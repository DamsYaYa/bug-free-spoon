using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public object applicationManager;

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

        public bool VerifyGroupIsPresent(int GroupIndex, GroupData groupData)
        {
            manager.Navigator.OpenGroupPage();

            while (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[{Index + 1}]")))
            {
                GroupData newGroupData = new GroupData("kkk");
                newGroupData.Header = null;
                newGroupData.Footer = null;
                CreateGroup(newGroupData);
            }

            return true;
        }

        private List<GroupData> groupCashe = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCashe == null)
            {
                groupCashe = new List<GroupData>();
                List<GroupData> groups = new List<GroupData>();
                manager.Navigator.OpenGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCashe.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }

            return new List<GroupData>(groupCashe);
        }


        public int GetGroupCount()
        {
           return driver.FindElements(By.CssSelector("span.group")).Count;
        }
         
        public GroupHelper Modify(GroupData group, GroupData newGroupData)
        {
            manager.Navigator.OpenGroupPage();

            SelectGroup(group.Id);
            InitGroupModification();
            FillForm(newGroupData);
            SubmitGroupModification();
           
            return this;
        }

        public GroupHelper InitGroupModification(GroupData group)
        {
            manager.Navigator.OpenGroupPage();

            SelectGroup(group.Id);
            InitGroupModification();
            FillForm(group);
            SubmitGroupModification();

            return this;
        }

        public GroupHelper RemoveGroup(int v)
        {
            manager.Navigator.OpenGroupPage();

            SelectGroup(0);
            RemoveSelectedGroup(0);
            manager.Navigator.OpenGroupPage();
            return this;
        }

        public GroupHelper RemoveGroup(GroupData group)
        {
            manager.Navigator.OpenGroupPage();

            SelectGroup(group.Id);
            RemoveSelectedGroup(0);
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
            groupCashe = null;
            return this;
        }
        public GroupHelper RemoveSelectedGroup(int index)
        {
            // Удаление группы
            driver.FindElement(By.XPath("(//input[@name='delete'])[" + (index+1) + "]")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            // Выбор группы
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + " ]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string Id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value= '"+Id+"'])")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            groupCashe = null;
            return this;
        }

        public bool ModificationCurrentGroup()
        {
            if (IsElementPresent(By.Name("edit")) 
                  && IsElementPresent (By.Name("selected[]")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
