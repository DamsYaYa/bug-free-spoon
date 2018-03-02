using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
     public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = applicationManager.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);

        }

        [Test]
        public void TestContactDetails()
        {
            applicationManager.Contacts.ModificationCurrentContact();
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromDetails = applicationManager.Contacts.GetContactInformationFromDetails(0);

            Assert.AreEqual(fromForm,fromDetails);
        }
    }
}
