using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData = new GroupData("kkk");
            newGroupData.Header = null;
            newGroupData.Footer = null;

            applicationManager.Groups.Modify(newGroupData);
        }
    }
}
