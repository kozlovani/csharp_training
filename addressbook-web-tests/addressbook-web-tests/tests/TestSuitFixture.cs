using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuitFixture
    {

        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void StopApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Auth.Logout();
            app.Stop();
        }
    }
}
