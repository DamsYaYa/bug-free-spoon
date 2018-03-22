using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        
        [Test]

        public bool ModificationCurrentContact()
        {
            applicationManager.Navigator.OpenHomePage();

            if (IsElementPresent(By.XPath("(//input[@name='selected[0]'])")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData(null, "Morskaya_pipiska");
            newContactData.Firstname = "Ekaterina";
            newContactData.Lastname = "Dams";

            if (ModificationCurrentContact() == false)
            {
                ContactData contact = new ContactData("Dams", "Ekaterina");
                applicationManager.Contacts.CreateContact(contact);

            }

            else if (ModificationCurrentContact() == true)
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