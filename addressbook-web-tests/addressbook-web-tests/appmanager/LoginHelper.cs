﻿using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
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
                if (IsLoggedIn(account)) {
                    return;
                }
                Logout();
            }
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text == "("+account.Username+")";
        }

        public void Logout()
        {
            if (IsLoggedIn()) { 
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

    }
}
