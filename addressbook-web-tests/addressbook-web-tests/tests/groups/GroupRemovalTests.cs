using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            //preparate
            int index = 5;
            app.Groups.CreateByIndex(index);
            Assert.IsTrue(app.Groups.CheckByIndex(index), "The group has not been created");

            //action
            app.Groups.Remove(index);

            //varification
            //Assert.IsTrue(app.Groups.GetCount() == (index - 1), "The group has not been removed");
        }
    }
}
