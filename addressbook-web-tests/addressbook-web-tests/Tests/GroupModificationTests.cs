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
            const int GroupIndex = 5;
            applicationManager.Groups.VerifyGroupIsPresent(GroupIndex, newGroupData);

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            GroupData toBeModified = oldGroups[GroupIndex];

            applicationManager.Groups.Modify(toBeModified, newGroupData);

            Assert.AreEqual(oldGroups.Count, applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();

            oldGroups[0].Name = newGroupData.Name;
            oldGroups[0].Footer = newGroupData.Footer;
            oldGroups[0].Header = newGroupData.Header;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newGroupData.Name, group.Name);
                    Assert.AreEqual(newGroupData.Footer, group.Footer);
                    Assert.AreEqual(newGroupData.Header, group.Header);
                }
            }         

        }   
    }
}


           