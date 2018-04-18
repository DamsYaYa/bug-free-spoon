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
            ContactData fromDetails = applicationManager.Contacts.GetContactInformationFromDetailsAndTrim(0);
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromDetails.AllInfo, fromForm.AllInfo);
        }
    }
}
