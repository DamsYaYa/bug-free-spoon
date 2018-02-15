﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContact : AuthTestBase
    {
        [Test]
        public void ContactCreatorTest()
        {
            ContactData contact = new ContactData("Ekaterina");          
            contact.Lastname = "Dams";

            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.AddNew();
            applicationManager.Contacts.CreateContact(contact);
            
            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }

        [Test]
        public void EmptyContactCreatorTest()
        {
            ContactData contact = new ContactData("");
            contact.Lastname = "";

            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.AddNew();
            applicationManager.Contacts.CreateContact(contact);

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }
    }
}
