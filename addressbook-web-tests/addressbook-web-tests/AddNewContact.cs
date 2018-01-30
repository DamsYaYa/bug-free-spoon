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
        public void AddNewContactTest()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.AddNew();
            ContactData contact = new ContactData("Ekaterina");
            contact.Lastname = "Dams";
            contactHelper.FillForm(contact);
            contactHelper.SubmitAdding();
            navigationHelper.ReturnToHomePage();
            loginHelper.Logout();
        }

    }
}
