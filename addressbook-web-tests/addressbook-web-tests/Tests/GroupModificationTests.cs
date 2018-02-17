using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData = new GroupData("kkk");
            newGroupData.Header = null;
            newGroupData.Footer = null;

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.ModificationCurrentGroup(newGroupData);

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups[0].Name = newGroupData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
