using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

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

        public static IEnumerable<ContactData> ContactDataFromFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Firstname = parts[2],
                    Lastname = parts[3]

                });
            }
            return contacts;
        }


        [Test, TestCaseSource("ContactDataFromFile")]
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

        [Test, TestCaseSource("ContactDataFromFile")]
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
