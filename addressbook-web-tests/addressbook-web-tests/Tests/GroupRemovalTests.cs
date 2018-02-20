using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveGroup : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            if (applicationManager.Groups.ModificationCurrentGroup() == true)
            {
                List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
                GroupData oldGroupData = oldGroups[0];
                applicationManager.Groups.RemoveGroup(0);

                Assert.AreEqual(oldGroups.Count - 1, applicationManager.Groups.GetGroupCount());
                List<GroupData> newGroups = applicationManager.Groups.GetGroupList();

                GroupData toBeRemoved = oldGroups[0];
                oldGroups.RemoveAt(0);
                Assert.AreEqual(oldGroups, newGroups);

                foreach (GroupData group in newGroups)
                {
                    Assert.AreNotEqual(group.Id, toBeRemoved.Id);
                }
            }
        }
    }
}
