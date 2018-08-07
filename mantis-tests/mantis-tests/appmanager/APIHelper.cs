using System.Collections.Generic;

namespace mantis_tests
{
    public class APIHelper
    {
        public APIHelper(ApplicationManager manager)
        {
            
        }
        public List<ProjectData> GetProjectList(AccountData account)
        {
            List < ProjectData > list = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach(Mantis.ProjectData project in projects)
            {
                list.Add(new ProjectData()
                {
                    Name = project.name
                });
            }
            client.Close();
            return list;
        }

        public void AddProject(AccountData account, ProjectData project)
        {
            List<ProjectData> list = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData mProject = new Mantis.ProjectData();
            mProject.name = project.Name;
            client.mc_project_add(account.Name, account.Password, mProject);
            client.Close();
        }
    }
}
