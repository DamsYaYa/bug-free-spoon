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

            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.ModificationCurrentContact(newContactData);

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }

    }
}