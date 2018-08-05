
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
            List<ProjectData> oldGroups = app.Projects.GetProjectList();

            //action
            Random rnd = new Random();
            ProjectData project = new ProjectData()
            {
                Name = "Test_" + rnd.Next()
            };          
            app.Projects.AddProject(project);
        
            //varification  
            List<ProjectData> newGroups = app.Projects.GetProjectList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            oldGroups.Add(project);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}