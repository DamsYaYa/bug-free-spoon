using System;
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
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]

        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Morskaya_pipiska");
            newContactData.Lastname = null;
            ContactData contact = new ContactData("Ekaterina");
            contact.Lastname = "Dams";

            applicationManager.Contacts.ModificationCurrentContact(newContactData);
        }

    }
}