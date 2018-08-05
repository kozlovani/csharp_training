using NUnit.Framework;

namespace addressbook_tests_white
{
    public class TestBase
    {
        public ApplicationManager app;

        [TestFixtureSetUp]
        public void initApplication()
        {
            app = new ApplicationManager();

        }

        [TestFixtureTearDown]
        public void stopAplication()
        {
            app.Stop();
        }
    }
}
