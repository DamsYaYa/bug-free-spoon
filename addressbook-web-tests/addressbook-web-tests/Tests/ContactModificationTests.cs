using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [SetUp]

        public void UpdateContact()
        {
            ContactData newContactData = new ContactData(null, "Morskaya_pipiska");
            newContactData.Firstname = "Ekaterina";
            newContactData.Lastname = "Dams";

            applicationManager.Contacts.CreateContact(newContactData);
        }
        
        [Test]

        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData(null, "Morskaya_pipiska");
            newContactData.Firstname = "Ekaterina";
            newContactData.Lastname = "Dams";

            if (applicationManager.Contacts.ModificationCurrentContact() == false)
            {
                ContactData contact = new ContactData("Dams", "Ekaterina");
                applicationManager.Contacts.CreateContact(contact);

            }

            else if (applicationManager.Contacts.ModificationCurrentContact() == true)
            {
                List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();
                ContactData toBeModified = oldContacts[0];

                applicationManager.Contacts.Modify(toBeModified, newContactData);

                Assert.AreEqual(oldContacts.Count, applicationManager.Contacts.GetContactCount());

                List<ContactData> newContacts = applicationManager.Contacts.GetContactList();

                oldContacts[0].Firstname = newContactData.Firstname;
                oldContacts[0].Lastname = newContactData.Lastname;
                oldContacts.Sort();
                newContacts.Sort();
                Assert.AreEqual(oldContacts, newContacts);

                foreach (ContactData contact in newContacts)
                {
                    if (contact.Id == toBeModified.Id)
                    {
                        Assert.AreEqual(newContactData.Firstname, contact.Firstname);
                        Assert.AreEqual(newContactData.Lastname, contact.Lastname);
                    }
                }
            }           

        }

    }
}