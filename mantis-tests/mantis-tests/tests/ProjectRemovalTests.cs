
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            //preparate
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            if (app.API.GetProjectList(account).Count == 0)
            {
                Random rnd = new Random();
                ProjectData project = new ProjectData()
                {
                    Name = "Test_" + rnd.Next()
                };
                app.API.AddProject(account, project);
            }
            
            List<ProjectData> oldGroups = app.API.GetProjectList(account);
            ProjectData toBeRemoved = oldGroups[0];

            //action
            app.Projects.Remove(0);

            //varification
            List<ProjectData> newGroups = app.API.GetProjectList(account);
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}