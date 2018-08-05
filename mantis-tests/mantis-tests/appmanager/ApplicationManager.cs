using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace mantis_tests
{
    

    public class ApplicationManager
    {

        protected IWebDriver driver;
        public string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper FtpHelper { get; set; }
        public LoginHelper Auth { get; set; }
        public ManagmentMenuHelper Navigator { get; set; }
        public ProjectManagementHelper Projects { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            Start();
            baseURL = "http://localhost:8080/mantisbt-2.16.0";
            Registration = new RegistrationHelper(this);
            FtpHelper = new FtpHelper(this);
            Auth = new LoginHelper(this);
            Navigator = new ManagmentMenuHelper(this);
            Projects = new ProjectManagementHelper(this);
        }

        ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated) {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost:8080/mantisbt-2.16.0/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        

        private void Start()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
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
