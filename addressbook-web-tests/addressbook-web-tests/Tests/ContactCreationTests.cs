using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

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

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
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

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {            
           return (List<ContactData>) new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }


        [Test, TestCaseSource("ContactDataFromCsvFile")]
        public void ContactCreationTest(ContactData contact)
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

        [Test, TestCaseSource("ContactDataFromCsvFile")]
        public void BadNameContactCreationTest(ContactData contact)
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
