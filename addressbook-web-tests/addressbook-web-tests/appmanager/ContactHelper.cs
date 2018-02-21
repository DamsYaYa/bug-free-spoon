﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
   public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base (manager)
        {
        }

        public ContactHelper AddNew()
        {
            manager.Navigator.OpenHomePage();

            //Добавление нового контакта
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();

           IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string Lastname = cells[1].Text;
            string Firstname = cells[2].Text;
            string Address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(Lastname, Firstname)
            {
                Address = Address,
                AllEmails = allEmails,
                AllPhones = allPhones,
            };


        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string Firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string Lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string Address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string HomePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string MobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string WorkPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string Email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string Email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string Email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(Lastname, Firstname)
            {
                Address = Address,
                HomePhone = HomePhone,
                MobilePhone = MobilePhone,
                WorkPhone = WorkPhone,
                Email = Email,
                Email2 = Email2,
                Email3 = Email3
            };
        }

        private List<ContactData> contactCashe = null;

        public List<ContactData> GetContactList()
        {
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();
                List<ContactData> contacts = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> table = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in table)
                {
                    string Lastname = element.FindElement(By.XPath("./td[2]")).Text;
                    string Firstname = element.FindElement(By.XPath("./td[3]")).Text;
                    contactCashe.Add(new ContactData(Lastname, Firstname)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

                }
            }

            return new List<ContactData>(contactCashe);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("selected[]")).Count;
        }
        public ContactHelper CreateContact(ContactData contact)
        {
            driver.FindElement(By.LinkText("add new")).Click();
            FillForm(contact);
            SubmitAdding();
            return this;
        }

        public ContactHelper Modify(ContactData newContactData)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(1);
            InitContactModification(0);
            FillForm(newContactData);
            SubmitContactModification();
            return this;
        }

            public ContactHelper RemoveContact(int v)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(0);
            RemoveSelectedContact();
            SubmitRemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper FillForm(ContactData contact)
        {
            //Заполнение полей ввода
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper SubmitAdding()
        {
            // Подтверждаем создание нового контакта
            driver.FindElement(By.Name("submit")).Click();
            contactCashe = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            // Выбор контакта
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + " ]")).Click();
            return this;
        }

        public ContactHelper RemoveSelectedContact()
        {
            // Удалить выбранный контакт
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitRemoveContact()
        {
            //Подтверждение удаления контакта
            driver.SwitchTo().Alert().Accept();
            contactCashe = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCashe = null;
            return this;
        }

        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElements(By.TagName("a")).Click();
        }

        public bool ModificationCurrentContact()
        {
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
