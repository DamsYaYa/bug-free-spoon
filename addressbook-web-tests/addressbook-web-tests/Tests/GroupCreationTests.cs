using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;


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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach(string l in lines)
            {
               string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
        }


        [Test, TestCaseSource("GroupDataFromCsvFile")]

        public void GroupCreationCsvTest(GroupData group)
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

        [Test, TestCaseSource("GroupDataFromXmlFile")]

        public void GroupCreationXmlTest(GroupData group)
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

        [Test, TestCaseSource("GroupDataFromCsvFile")]
        public void BadNameGroupCreationTest(GroupData group)
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

