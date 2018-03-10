using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData = new GroupData("kkk");
            newGroupData.Header = null;
            newGroupData.Footer = null;

            if (applicationManager.Groups.ModificationCurrentGroup() == true)
            {
                GroupData group = new GroupData("aaa");
                group.Header = "bbb";
                group.Footer = "ccc";

                applicationManager.Groups.CreateGroup(group);

            }

            else if(applicationManager.Groups.ModificationCurrentGroup() ==  false)
            {
                List<GroupData> oldGroups = GroupData.GetAll();
                GroupData oldGroupData = oldGroups[0];
                GroupData toBeModified = oldGroups[0];
                applicationManager.Groups.InitGroupModification(toBeModified);

                Assert.AreEqual(oldGroups.Count, applicationManager.Groups.GetGroupCount());

                List<GroupData> newGroups = GroupData.GetAll();
                oldGroups[0].Name = newGroupData.Name;
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
                Assert.AreEqual(oldGroups, newGroups);

                foreach (GroupData group in newGroups)
                {
                    if (group.Id == oldGroupData.Id)
                    {
                        Assert.AreEqual(newGroupData.Name, group.Name);
                    }
                }
            }              

        }   
    }
}
