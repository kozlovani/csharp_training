using addressbook_tests_autoit.model;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            //preparate 
            if (app.Groups.GetGroupCount() == 0)
            {
                app.Groups.AddGroup(new GroupData() {
                    Name = "New Group1"
                });
                app.Groups.AddGroup(new GroupData()
                {
                    Name = "New Group2"
                });
            } else if (app.Groups.GetGroupCount() == 1)
            {
                app.Groups.AddGroup(new GroupData()
                {
                    Name = "New Group3"
                });
            }
                List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];

            //action
            app.Groups.DeleteGroup(0);

            //varification

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            newGroups.Sort();
            oldGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
