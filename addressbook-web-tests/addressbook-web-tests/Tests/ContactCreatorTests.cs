using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContact : AuthTestBase
    {
        [Test]
        public void ContactCreatorTest()
        {
            ContactData contact = new ContactData("Dams", "Ekaterina");          
            contact.Lastname = "Dams";

            

            if (applicationManager.Contacts.ModificationCurrentContact() == false)
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

        [Test]
        public void EmptyContactCreatorTest()
        {
            ContactData contact = new ContactData("","");
            contact.Lastname = "";

     

            if (applicationManager.Contacts.ModificationCurrentContact() == false)
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

        [Test]
        public void BadNameContactCreatorTest()
        {
            ContactData contact = new ContactData("a'a","");
            contact.Lastname = "";



            if (applicationManager.Contacts.ModificationCurrentContact() == false)
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
}
