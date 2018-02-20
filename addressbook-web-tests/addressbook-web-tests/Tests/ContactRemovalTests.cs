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

            Assert.AreEqual(oldContacts.Count - 1, applicationManager.Contacts.GetContactCount());

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}