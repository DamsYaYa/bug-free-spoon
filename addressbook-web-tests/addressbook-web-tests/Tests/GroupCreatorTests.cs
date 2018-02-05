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
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";

            applicationManager.Groups.CreateGroup(group);
        }

        [Test]
        public void EmptyGroupCreatorTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            applicationManager.Groups.CreateGroup(group);
        }

        private void FillForm(GroupData group)
        {
            throw new NotImplementedException();
        }
    }
}

