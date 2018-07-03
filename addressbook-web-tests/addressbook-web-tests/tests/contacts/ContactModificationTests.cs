using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            
            
            //preparate
            int index = 5;
            app.Contacts.CreateByIndex(index);
            Assert.IsTrue(app.Contacts.CheckByIndex(index), "The contact has not been created");

            //action
            ContactData newData = new ContactData("Update FirstName", "Update LastName");
            newData.MiddleName = "Update MiddleName";
            app.Contacts.Modify(index, newData);

            //varification
            //Assert.IsTrue(app.Contacts.GetByIndex(index).Compare(newData), "The contact has not been changed");

        }
    }
}