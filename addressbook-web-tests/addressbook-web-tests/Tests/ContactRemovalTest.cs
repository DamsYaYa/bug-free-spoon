using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveContact : TestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            applicationManager.Navigator.OpenHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Contacts.SelectContact();
            applicationManager.Contacts.RemoveSelectedContact();
            applicationManager.Contacts.SubmitRemoveContact();
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Logout();
        }
    }
}