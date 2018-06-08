using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToNewContactPage();
            ContactData contact = new ContactData("Ivanov","Ivan");
            contact.MiddleName = "Ivanovich";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            Logout();
        }

        

        
   
    }
}
