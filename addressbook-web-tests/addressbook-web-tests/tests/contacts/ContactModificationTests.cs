using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Update FirstName", "Update LastName");
            newData.MiddleName = "Update MiddleName";
            app.Contacts.Modify(5, newData);
        }
    }
}