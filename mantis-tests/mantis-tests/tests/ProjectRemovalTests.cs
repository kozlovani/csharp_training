
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
            if (app.Projects.GetProjectCount() == 0)
            {
                Random rnd = new Random();
                ProjectData project = new ProjectData()
                {
                    Name = "Test_" + rnd.Next()
                };
                app.Projects.AddProject(project);
            }
            List<ProjectData> oldGroups = app.Projects.GetProjectList();
            ProjectData toBeRemoved = oldGroups[0];

            //action
            app.Projects.Remove(0);

            //varification
            List<ProjectData> newGroups = app.Projects.GetProjectList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}