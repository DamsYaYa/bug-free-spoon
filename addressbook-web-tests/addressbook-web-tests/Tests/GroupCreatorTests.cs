using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroup : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });           
            
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]

        public void GroupCreatorTest(GroupData group)
        {
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            GroupData oldGroupData = oldGroups[0];

            applicationManager.Groups.CreateGroup(group);
            applicationManager.Navigator.OpenGroupPage();

            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
                oldGroups.Add(group);
                oldGroups.Sort();
                newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);                       
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void BadNameGroupCreatorTest(GroupData group)
        {
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            GroupData oldGroupData = oldGroups[0];

            applicationManager.Groups.CreateGroup(group);

            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
                oldGroups.Add(group);
                oldGroups.Sort();
                newGroups.Sort();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);                    
        }
    }
}

