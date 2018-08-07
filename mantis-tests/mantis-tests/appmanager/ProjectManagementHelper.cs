using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {

        }

        public int GetProjectCount()
        {
            manager.Navigator.GotoManageProjectPage();
            return driver.FindElements(By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr")).Count;
        }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> list = new List<ProjectData>();
            manager.Navigator.GotoManageProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr"));
            foreach (IWebElement element in elements)
            {
                list.Add(new ProjectData()
                {
                    Name = element.FindElements(By.XPath("td"))[0].Text
                });
            }
            return list;
        }

        internal void Remove(int index)
        {
            manager.Navigator.GotoManageProjectPage();
            SelectProject(index);
            SubmitRemoveButton();
        }

        private void SubmitRemoveButton()
        {
            driver.FindElement(By.XPath("//*[@id='project-delete-form']/fieldset/input[3]")).Click();
            driver.FindElement(By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/form/input[4]")).Click();

        }

        private void SelectProject(int index)
        {
            driver.FindElements(By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a"))[index].Click();
        }

        public void AddProject(ProjectData project)
        {
            manager.Navigator.GotoManageProjectPage();
            SubmitCreateProjectButton();
            FillProjectForm(project);
            SubmitAddProjectButton();
        }

        private void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
        }

        private void SubmitAddProjectButton()
        {
            driver.FindElement(By.XPath("//*[@id='manage-project-create-form']/div/div[3]/input")).Click();
        }

        public void SubmitCreateProjectButton()
        {
            driver.FindElement(By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[1]/form/fieldset/button")).Click();
        }
    }
}
