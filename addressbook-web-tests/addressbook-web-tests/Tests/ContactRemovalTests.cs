﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveContact : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            if (applicationManager.Contacts.ModificationCurrentContact() == true)
            {

                List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();
                ContactData oldContactData = oldContacts[0];

                applicationManager.Contacts.RemoveContact(0);

                Assert.AreEqual(oldContacts.Count - 1, applicationManager.Contacts.GetContactCount());
                List<ContactData> newContacts = applicationManager.Contacts.GetContactList();

                ContactData toBeRemoved = oldContacts[0];
                oldContacts.RemoveAt(0);
                Assert.AreEqual(oldContacts, newContacts);

                foreach (ContactData contact in newContacts)
                {
                    Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
                }
            }

            else if (applicationManager.Contacts.ModificationCurrentContact() == false)
            {
                ContactData contact = new ContactData("Dams","Ekaterina");
                contact.Lastname = "Dams";
                applicationManager.Contacts.CreateContact(contact);
            }   

        }
    }
}