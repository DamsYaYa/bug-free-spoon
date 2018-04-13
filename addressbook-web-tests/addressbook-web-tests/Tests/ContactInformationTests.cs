using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
     public class ContactInformationTests : AuthTestBase
    {
        ContactData newContactData = new ContactData(null, "Morskaya_pipiska");

        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = applicationManager.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable.Firstname, fromForm.Firstname);
            Assert.AreEqual(fromTable.Lastname, fromForm.Lastname);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            
        }

        [Test]
        public void TestContactDetails()
        {
            const int ContactIndex = 5;
            applicationManager.Contacts.VerifyContactIsPresent(ContactIndex, newContactData);
            ContactData ContactDetails = applicationManager.Contacts.GetContactInformationFromDetails(ContactIndex);
            ContactData ContactEditForm = applicationManager.Contacts.GetContactInformationFromEditForm(ContactIndex);

            Assert.AreEqual(ContactEditForm.AllInfo, ContactDetails.AllInfo);
        }
    }
}
