using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            GoToNewContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public int GetCount()
        {
            manager.Navigator.GoToHomePage();
            return Convert.ToInt32(driver.FindElement(By.Id("search_count")).Text);
        }
        public bool CheckByIndex(int index)
        {
            var count = GetCount();
            if (count >= index)
                return true;
            else
                return false;
        }

        public ContactHelper CreateByIndex(int index)
        {
            var count = GetCount();
            if (count < index)
            {
                for (int i = count; i < index; i++)
                {
                    Create(new ContactData("", ""));
                }
            };
            return this;
        }
        public ContactData GetByIndex(int index)
        {
            ContactData contact = null;
            if (CheckByIndex(index)) contact = new ContactData(driver.FindElement(By.XPath("//table//tr[" + index + "+1]/td[3]")).Text, driver.FindElement(By.XPath("//table//tr[" + index + "+1]/td[2]")).Text);
            return contact;
        }

        public ContactHelper Select(int index)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper Remove(int i)
        {
            Select(i);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper Modify(int i, ContactData contact)
        {
            Select(i);
            FillContactForm(contact);
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.NickName);
            Type(By.Name("photo"), contact.Photo);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.HomePage);

            Select(By.Name("bday"), contact.BDay);
            Select(By.Name("bmonth"), contact.BMonth);

            Type(By.Name("byear"), contact.BYear);

            Select(By.Name("aday"), contact.ADay);
            Select(By.Name("amonth"), contact.AMonth);

            Type(By.Name("ayear"), contact.AYear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper GoToNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

    }
}
