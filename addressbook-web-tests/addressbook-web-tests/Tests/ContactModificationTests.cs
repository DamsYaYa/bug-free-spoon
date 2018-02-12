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
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        protected IWebDriver driver;

        [Test]
        public void ContactModificationTest()
        {

            ContactData newContactData = new ContactData("Morskaya_pipiska");
            newContactData.Lastname = null;
            ContactData contact = new ContactData("Ekaterina");
            contact.Lastname = "Dams";

            if (IsElementPresent(By.Name("selected")))
            {
                applicationManager.Contacts.Modify(newContactData);
            }

            else
            {
                applicationManager.Contacts.AddNew();
                applicationManager.Contacts.CreateContact(contact);
            }
        }
        public bool IsElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}