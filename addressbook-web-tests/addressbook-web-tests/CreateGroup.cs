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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            OpenGroupPage();
            CreateNewGroup();
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";
            FillForm(group);
            SubmitGroupCreate();
            ReturnToGroupPage();
            Logout();
        }
    }
}

