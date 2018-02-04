﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContact : TestBase
    {
        [Test]
        public void ContactCreatorTest()
        {
            ContactData contact = new ContactData("Ekaterina");          
            contact.Lastname = "Dams";
            
            applicationManager.Contacts.AddNew();
            applicationManager.Contacts.CreateContact(contact);            
            applicationManager.Auth.Logout();
        }

        [Test]
        public void EmptyContactCreatorTest()
        {
            ContactData contact = new ContactData("");
            contact.Lastname = "";
            
            applicationManager.Contacts.AddNew();
            applicationManager.Contacts.CreateContact(contact);            
            applicationManager.Auth.Logout();
        }
    }
}
