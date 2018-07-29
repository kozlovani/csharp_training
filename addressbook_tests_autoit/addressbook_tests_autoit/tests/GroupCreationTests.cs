using System;
using System.Collections.Generic;
using addressbook_tests_autoit.model;
using NUnit.Framework;

namespace addressbook_tests_autoit
{ 
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [TestMethod]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData() {
                Name = "Test"
            };

            app.Groups.AddGroup(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
