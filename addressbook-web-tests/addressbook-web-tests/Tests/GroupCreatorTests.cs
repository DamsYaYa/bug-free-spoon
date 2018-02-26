using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroup : AuthTestBase
    {
       [Test]
        public void GroupCreatorTest()
        {                  
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";


            if (applicationManager.Groups.ModificationCurrentGroup() == false)
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
        }

        [Test]
        public void EmptyGroupCreatorTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";            

            if (applicationManager.Groups.ModificationCurrentGroup() == false)
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

        [Test]
        public void BadNameGroupCreatorTest()
        {

            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";


            if (applicationManager.Groups.ModificationCurrentGroup() == false)
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
}

