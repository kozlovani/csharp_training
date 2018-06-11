using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("z");
            newData.Header = "z";
            newData.Footer = "z";
            app.Groups.Modify(1, newData);
        }
    }
}
