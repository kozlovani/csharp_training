using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            //preparate
            int index = 3;
            app.Groups.CreateByIndex(index);
            Assert.IsTrue(app.Groups.CheckByIndex(index), "The group has not been created");

            //action
            GroupData newData = new GroupData("z");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Modify(index, newData);

            //varification
            //Assert.IsTrue(app.Groups.GetByIndex(index).Compare(newData), "The group has not been changed");
        }
    }
}
