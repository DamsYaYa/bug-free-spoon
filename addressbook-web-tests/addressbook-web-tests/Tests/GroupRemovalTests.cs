using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveGroup : GroupTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            GroupData newGroupData = new GroupData("kkk");
            const int GroupIndex = 5;
            applicationManager.Groups.VerifyGroupIsPresent(GroupIndex, newGroupData);
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData removeGroup = oldGroups[GroupIndex];

            applicationManager.Groups.RemoveGroup(GroupIndex);

            Assert.AreEqual(oldGroups.Count - 1, applicationManager.Groups.GetGroupCount());
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.RemoveAt(GroupIndex);
            newGroups.Sort();
            oldGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, removeGroup.Id);
            }           
            
        }
    }
}



       
          

