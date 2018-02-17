using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveContact : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            if (applicationManager.Contacts.ModificationCurrentContact() == true)
            {
                applicationManager.Contacts.RemoveContact(0);
            }

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}