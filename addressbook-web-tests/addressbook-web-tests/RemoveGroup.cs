using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveGroup : TestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.OpenGroupPage();
            groupHelper.SelectGroup();
            groupHelper.RemoveSelectedGroup(1);
            navigationHelper.ReturnToHomePage();
            loginHelper.Logout();
        }
    }
}
