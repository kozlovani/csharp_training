using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.GoToNewContactPage();
            ContactData contact = new ContactData("Ivanov","Ivan");
            contact.MiddleName = "Ivanovich";
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactCreation();
            contactHelper.ReturnToHomePage();
            loginHelper.Logout();
        }

        

        
   
    }
}
