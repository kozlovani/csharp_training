using System;
using OpenQA.Selenium;

namespace mantis_tests
{

    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.XPath("//*[@id='login-form']/fieldset/input[2]")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//*[@id='login-form']/fieldset/input[3]")).Click();
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.ClassName("span.user-info"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Name;

        }

        private string GetLoggetUserName()
        {
            return driver.FindElement(By.ClassName("span.user-info")).Text;
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.Url ="http://localhost:8080/mantisbt-2.16.0/login_page.php";
            }
        }

    }
}
