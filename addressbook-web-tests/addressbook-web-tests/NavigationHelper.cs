using OpenQA.Selenium;

namespace WebAddressbookTests
{   
    public class NavigationHelper
    {
        private IWebDriver driver;
        private string baseURL;
        public NavigationHelper(IWebDriver driver, string baseURL)
        {
            this.driver = driver;
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}
