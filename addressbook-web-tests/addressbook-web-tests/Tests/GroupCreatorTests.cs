using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.CreateGroup(group);

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreatorTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.CreateGroup(group);

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreatorTest()
        {

            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.CreateGroup(group);

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}

