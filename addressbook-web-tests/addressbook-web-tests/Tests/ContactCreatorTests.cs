using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContact : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(100),
                    Lastname = GenerateRandomString(100)
                });

            }
            return contacts;
        }


        [Test, TestCaseSource("RandomComtactDataProvider")]
        public void ContactCreatorTest(ContactData contact)
        {
            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();
            ContactData oldContactData = oldContacts[0];

            applicationManager.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
                oldContacts.Add(contact);
                oldContacts.Sort();
                newContacts.Sort();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);           
        }

        [Test, TestCaseSource("RandomComtactDataProvider")]
        public void BadNameContactCreatorTest(ContactData contact)
        {
            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();
            ContactData oldContactData = oldContacts[0];

            applicationManager.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
                oldContacts.Add(contact);
                oldContacts.Sort();
                newContacts.Sort();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);                        
        }
    }
}
