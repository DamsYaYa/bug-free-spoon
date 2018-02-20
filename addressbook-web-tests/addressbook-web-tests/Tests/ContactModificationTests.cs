using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]

        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData(null, "Morskaya_pipiska");
            newContactData.Lastname = null;

            if (applicationManager.Contacts.ModificationCurrentContact() == true)
            {
                List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();
                ContactData oldContactData = oldContacts[0];
                applicationManager.Contacts.InitContactModification();

                Assert.AreEqual(oldContacts.Count, applicationManager.Contacts.GetContactCount());


                List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
                oldContacts[0].Firstname = newContactData.Firstname;
                oldContacts.Sort();
                newContacts.Sort();
                Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
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

            else if (applicationManager.Contacts.ModificationCurrentContact() == false)
            {
                ContactData contact = new ContactData("Dams","Ekaterina");
                contact.Lastname = "Dams";
                applicationManager.Contacts.CreateContact(contact);
            }           

        }

    }
}