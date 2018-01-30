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
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.GoToHomePage();
            contactHelper.SelectContact();
            contactHelper.RemoveSelectedContact();
            contactHelper.SubmitRemoveContact();
            navigationHelper.ReturnToHomePage();
            loginHelper.Logout();
        }
    }
}