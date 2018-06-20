using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //preparate
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //varification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            //preparate
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "wrong");
            app.Auth.Login(account);

            //varification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
