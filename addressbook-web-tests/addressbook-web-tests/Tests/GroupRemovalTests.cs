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
            if (applicationManager.Groups.ModificationCurrentGroup() == true)
            {
                List<GroupData> oldGroups = GroupData.GetAll();
                GroupData oldGroupData = oldGroups[0];
                GroupData toBeRemoved = oldGroups[0];
                applicationManager.Groups.RemoveGroup(toBeRemoved);

                Assert.AreEqual(oldGroups.Count - 1, applicationManager.Groups.GetGroupCount());
                List<GroupData> newGroups = GroupData.GetAll();

               
                oldGroups.RemoveAt(0);
                Assert.AreEqual(oldGroups, newGroups);

                foreach (GroupData group in newGroups)
                {
                    Assert.AreNotEqual(group.Id, toBeRemoved.Id);
                }
            }
            else if (applicationManager.Groups.ModificationCurrentGroup() == false)
            {
                GroupData group = new GroupData("kkk");
                applicationManager.Groups.CreateGroup(group);
            }
        }
    }
}
