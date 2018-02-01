using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContact : TestBase
    {
        [Test]
        public void AddNewContactTest()
        {
            applicationManager.Navigator.OpenHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Contacts.AddNew();
            ContactData contact = new ContactData("Ekaterina");
            contact.Lastname = "Dams";
            applicationManager.Contacts.FillForm(contact);
            applicationManager.Contacts.SubmitAdding();
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Logout();
        }

    }
}
