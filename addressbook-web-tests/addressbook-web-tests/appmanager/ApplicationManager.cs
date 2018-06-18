using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace WebAddressbookTests
{
    

    public class ApplicationManager
    {

        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ApplicationManager instance;

        private ApplicationManager()
        {
            Start();
            baseURL = "http://localhost:8080/";
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (instance == null) {
                instance = new ApplicationManager();
            }
            return instance;
        }

        private void Start()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }

    
}
