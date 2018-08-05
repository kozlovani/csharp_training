
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {   
        [TestFixtureSetUp]
        public void SetUpConfig()
        {
            app.FtpHelper.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php",FileMode.Open))
            {
                app.FtpHelper.Upload("/config_inc.php", localFile);
            }     
        }

        [Test]
        public void AccountCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localadmin"
            };

            app.Registration.Register(account);

        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            app.FtpHelper.RestoreBackupFile("/config_inc.php");
        }
    }
}
