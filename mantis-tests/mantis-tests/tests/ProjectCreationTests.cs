
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void AccountProjectCreationTest()
        {
            //preparate
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            List<ProjectData> oldGroups = app.API.GetProjectList(account);

            //action
            Random rnd = new Random();
            ProjectData project = new ProjectData()
            {
                Name = "Test_" + rnd.Next()
            };          
            app.Projects.AddProject(project);
        
            //varification  
            List<ProjectData> newGroups = app.API.GetProjectList(account);
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            oldGroups.Add(project);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}