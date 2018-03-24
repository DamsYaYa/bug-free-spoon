using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveContact : ContactTestBase
    {

        [Test]

        public void ContactRemovalTest()
        {
            ContactData newContactData = new ContactData(null, "Morskaya_pipiska");
            const int ContactIndex = 5;
            applicationManager.Contacts.VerifyContactIsPresent(ContactIndex, newContactData);
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData removeContact = oldContacts[ContactIndex];

            applicationManager.Contacts.RemoveContact(ContactIndex);

            Assert.AreEqual(oldContacts.Count - 1, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
            oldContacts.RemoveAt(ContactIndex);
            newContacts.Sort();
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, removeContact.Id);
            }
        }
    }
}



       