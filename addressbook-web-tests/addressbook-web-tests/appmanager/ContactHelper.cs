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

        public ContactHelper CreateContact(ContactData contact)
        {
            FillForm(contact);
            SubmitAdding();
            return this;
        }

        public ContactHelper Modify(ContactData newContactData)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(1);
            InitContactModification();
            FillForm(newContactData);
            SubmitContactModification();
            return this;
        }

            public ContactHelper RemoveContact()
        {
            manager.Navigator.OpenHomePage();

            SelectContact(1);
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
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
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
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            // Выбор контакта
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + " ]")).Click();
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
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper ModificationCurrentContact(ContactData newContactData)
        {
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])")))
            {
                manager.Contacts.Modify(newContactData);
            }
            else
            {
                ContactData contact = new ContactData("Ekaterina");
                contact.Lastname = "Dams";
                manager.Contacts.CreateContact(contact);
            }
            return this;
        }
    }
}
