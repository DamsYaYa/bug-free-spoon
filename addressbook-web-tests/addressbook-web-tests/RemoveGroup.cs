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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            OpenGroupPage();
            SelectGroup();
            RemoveSelectedGroup(1);
            ReturnToHomePage();
        }
    }
}
