using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            
            //preparate
            int index = 7;
            app.Contacts.CreateByIndex(index);
            Assert.IsTrue(app.Contacts.CheckByIndex(index), "The contact has not been created");

            //action
            app.Contacts.Remove(index);

            //varification
            //Assert.IsTrue(app.Contacts.GetCount() == (index-1), "The contact has not been removed");
        }

    }
}