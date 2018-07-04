using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            //preparate
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            GroupData group = new GroupData("a");
            group.Header = "b";
            group.Footer = "c";
            app.Groups.Create(group);

            //varification
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {  

            //preparate
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);

            //varification
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {

            //preparate
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);

            //varification
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
