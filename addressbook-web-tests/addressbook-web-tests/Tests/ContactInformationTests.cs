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

            Assert.AreEqual(fromTable.Firstname, fromForm.Firstname);
            Assert.AreEqual(fromTable.Lastname, fromForm.Lastname);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            
        }

        [Test]
        public void TestContactDetails()
        {
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);

            if (fromForm.Firstname != "" && fromForm.Lastname != "" && fromForm.HomePhone != "" &&
               fromForm.MobilePhone != "" && fromForm.WorkPhone != "" &&
               fromForm.Email != "" && fromForm.Email2 != "" && fromForm.Email3 != "")
            {
                ContactData fromDetailsPage = applicationManager.Contacts.GetContactInformationFromDetails(0);
                Assert.AreEqual(fromForm.Firstname + " " + fromForm.Lastname + "\r\n"
                   + "\r\nH: " + fromForm.HomePhone + "\r\nM: " + fromForm.MobilePhone + "\r\nW: " + fromForm.WorkPhone + "\r\n"
                   + "\r\n" + fromForm.Email + "\r\n" + fromForm.Email2 + "\r\n" + fromForm.Email3, fromDetailsPage.ContactDetailsText);
            }
            else if (fromForm.Firstname == "" || fromForm.Lastname == "" || fromForm.HomePhone == "" ||
                fromForm.MobilePhone == "" || fromForm.WorkPhone == "" ||
                fromForm.Email == "" || fromForm.Email2 == "" || fromForm.Email3 == "")
            {
                ContactData fromDetailsPageTrim = applicationManager.Contacts.GetContactInformationFromDetailsAndTrim(0);
                Assert.AreEqual(fromForm.Firstname + fromForm.Lastname
                + fromForm.HomePhone + fromForm.MobilePhone + fromForm.WorkPhone
                + fromForm.Email + fromForm.Email2 + fromForm.Email3, fromDetailsPageTrim.ContactDetailsTextTrim);
            }
        }
    }
}
