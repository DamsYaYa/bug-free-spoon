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
        public void CreatorGroupsTest()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.OpenGroupPage();
            groupHelper.CreateNewGroup();
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";
            groupHelper.FillForm(group);
            groupHelper.SubmitGroupCreate();
            navigationHelper.ReturnToGroupPage();
            loginHelper.Logout();
        }

        private void FillForm(GroupData group)
        {
            throw new NotImplementedException();
        }
    }
}

