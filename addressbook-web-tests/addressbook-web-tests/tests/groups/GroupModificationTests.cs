using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            //preparate
            if (app.Groups.GetGroupCount() == 0)
            {
                app.Groups.Create(new GroupData(""));
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            GroupData newData = new GroupData("m");
            newData.Id = oldData.Id;
            newData.Header = null;
            newData.Footer = null;

            //action
            app.Groups.Modify(newData);

            //varification
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
