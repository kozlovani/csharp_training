using System;
using System.Linq;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
   public  class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            DeleteGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public int GetCount()
        {
            manager.Navigator.GoToGroupsPage();
            return driver.FindElements(By.Name("selected[]")).Count();
        }
        public bool CheckByIndex(int index)
        {
            var count = GetCount();
            if (count >= index)
                return true;
            else
                return false;
        }

        public GroupHelper CreateByIndex(int index)
        {
            var count = GetCount();
            if (count < index)
            {
                for (int i = count; i < index; i++)
                {
                    Create(new GroupData(""));
                }
            };
            return this;
        }
        public GroupData GetByIndex(int index)
        {
            GroupData group = null;
            if (CheckByIndex(index)) group = new GroupData(driver.FindElement(By.XPath("//*[@id='content']/form/span["+index+"]")).Text);
            return group;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }


        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            var count = driver.FindElements(By.XPath("(//input[@name='selected[]'])")).Count();
            if (count < index)
            {
                for (int i = count; i < index; i++)
                {
                    Create(new GroupData(""));
                }
            };
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
    }
}
