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
                List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
                GroupData toBeModified = oldGroups[0];

                applicationManager.Groups.Modify(toBeModified.Id, newGroupData);

                Assert.AreEqual(oldGroups.Count, applicationManager.Groups.GetGroupCount());

                List<GroupData> newGroups = applicationManager.Groups.GetGroupList();

                oldGroups[0].Name = newGroupData.Name;
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups);

                foreach (GroupData group in newGroups)
                {
                    if (group.Id == toBeModified.Id)
                    {
                        Assert.AreEqual(newGroupData.Name, group.Name);
                    }
                }
            }

            else if(applicationManager.Groups.ModificationCurrentGroup() ==  false)
            {
                GroupData group = new GroupData("kkk");
                applicationManager.Groups.CreateGroup(group);
            }              
        }   
    }
}
