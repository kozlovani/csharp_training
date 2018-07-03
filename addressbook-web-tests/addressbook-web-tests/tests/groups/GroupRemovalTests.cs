using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            //preparate
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count == 0)
            {
                app.Groups.Create(new GroupData(""));
            }

            //action
            app.Groups.Remove(1);

            //varification
            //List<GroupData> newGroups = app.Groups.GetGroupList();
            //oldGroups.RemoveAt(index - 1);
        }
    }
}
