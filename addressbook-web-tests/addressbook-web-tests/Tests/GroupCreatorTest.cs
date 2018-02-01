using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroup : TestBase
    {
       [Test]
        public void GroupCreatorTest()
        {
            applicationManager.Navigator.OpenHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Navigator.OpenGroupPage();
            applicationManager.Groups.CreateNewGroup();
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";
            applicationManager.Groups.FillForm(group);
            applicationManager.Groups.SubmitGroupCreate();
            applicationManager.Navigator.OpenGroupPage();
            applicationManager.Auth.Logout();
        }

        private void FillForm(GroupData group)
        {
            throw new NotImplementedException();
        }
    }
}

