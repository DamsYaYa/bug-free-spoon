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
            applicationManager.Navigator.OpenHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Navigator.OpenGroupPage();
            applicationManager.Groups.SelectGroup();
            applicationManager.Groups.RemoveSelectedGroup(1);
            applicationManager.Navigator.OpenGroupPage();
            applicationManager.Auth.Logout();
        }
    }
}
