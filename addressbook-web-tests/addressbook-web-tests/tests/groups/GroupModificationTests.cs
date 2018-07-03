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
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count == 0)
            {
                app.Groups.Create(new GroupData(""));
            }

            //action
            GroupData newData = new GroupData("z");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Modify(1, newData);

            //varification

        }
    }
}
