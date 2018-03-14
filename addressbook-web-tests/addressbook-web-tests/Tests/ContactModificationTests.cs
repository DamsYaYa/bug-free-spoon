using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {

        [Test]

        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData(null, "Morskaya_pipiska");
            newContactData.Lastname = "Dams";

            if (applicationManager.Contacts.ModificationCurrentContact() == true)
            {
                ContactData contact = new ContactData("Dams", "Ekaterina");
                contact.Lastname = "Dams";
                applicationManager.Contacts.CreateContact(contact);
            }

            else if (applicationManager.Contacts.ModificationCurrentContact() == false)
            {
                List<ContactData> oldContacts = ContactData.GetAll();
                ContactData oldContactData = oldContacts[0];
                ContactData toBeModified = oldContacts[0];
                applicationManager.Contacts.InitContactModification(0);
                applicationManager.Navigator.GoToHomePage();


                Assert.AreEqual(oldContacts.Count, applicationManager.Contacts.GetContactCount());


                List<ContactData> newContacts = ContactData.GetAll();
                oldContacts[0].Firstname = newContactData.Firstname;
                oldContacts.Sort();
                newContacts.Sort();
                Assert.AreEqual(oldContacts, newContacts);

                foreach (ContactData contact in newContacts)
                {
                    if (contact.Id == oldContactData.Id)
                    {
                        Assert.AreEqual(newContactData.Firstname, contact.Firstname);
                        Assert.AreEqual(newContactData.Lastname, contact.Lastname);
                    }
                }
            }           

        }

    }
}