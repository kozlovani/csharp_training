using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            //preparate
            if (app.Groups.GetGroupList().Count == 0)
            {
                app.Groups.Create(new GroupData(""));
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            GroupData newData = new GroupData("z");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Modify(0, newData);

            //varification
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
