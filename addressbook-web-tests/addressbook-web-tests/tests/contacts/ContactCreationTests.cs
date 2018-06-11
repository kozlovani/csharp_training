using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        { 
            ContactData contact = new ContactData("Ivan", "Ivanov");
            contact.MiddleName = "Ivanovich";
            app.Contacts.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            contact.MiddleName = "";
            app.Contacts.Create(contact);
        }

    }
}
