using OpenQA.Selenium;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactData GetContactInformationFromDetailsForm(int index)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("(//img[@title='Details'])[" + (index + 1) + "]")).Click();

            string text = Regex.Replace(driver.FindElement(By.Id("content")).Text.Replace("\r\n\r\n", "\r\n"), @" \(\d+\)", "");

            return new ContactData("", "")
            {
                AllData = text
            };
        }


        public ContactHelper Modify(ContactData contact)
        {
            Select(contact.Id);
            FillContactForm(contact);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Remove(ContactData toBeRemoved)
        {
            Select(toBeRemoved.Id);
            SubmitContactRemoval();
            //this.driver.SwitchTo().Alert().Accept();
            return this;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectByCheckbox(contact.Id);
            SelectGroupToAdd(group.Name);
            SubmitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }


        public void RemoveContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SetGroupFilter(group.Name);
            SelectByCheckbox(contact.Id);
            SubmitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void SubmitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();    
        }

        private void SelectByCheckbox(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public void SubmitAddingContactToGroup()
        {
            
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void Select(string id)
        {
            driver.FindElement(By.CssSelector("a[href= 'edit.php?id=" + id+"']")).Click();
            
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
        public void SetGroupFilter(string value)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(value);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            Select(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bDay = driver.FindElement(By.Name("bday")).FindElements(By.XPath("./option[@selected]"))[0].Text;
            string bMonth = driver.FindElement(By.Name("bmonth")).FindElements(By.XPath("./option[@selected]"))[0].Text;
            string bYear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aDay = driver.FindElement(By.Name("aday")).FindElements(By.XPath("./option[@selected]"))[0].Text;
            string aMonth = driver.FindElement(By.Name("amonth")).FindElements(By.XPath("./option[@selected]"))[0].Text;
            string aYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName) {
                MiddleName = middleName,
                NickName = nickName,
                Company = company,
                Title = title,
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                HomePage = homePage,
                BDay = bDay,
                BMonth = bMonth,
                BYear = bYear,
                ADay = aDay,
                AMonth = aMonth,
                AYear = aYear,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };
                
        }

        public ContactHelper Create(ContactData contact)
        {
            GoToNewContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                manager.Navigator.GoToHomePage();
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElement(By.XPath("td[3]")).Text, element.FindElement(By.XPath("td[2]")).Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return contactCache;
        }

        public int GetContactCount()
        {

            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactHelper Select(int index)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper Remove(int i)
        {
            Select(i);
            SubmitContactRemoval();
            return this;
        }

        public ContactHelper Modify(int i, ContactData contact)
        {
            Select(i);
            FillContactForm(contact);
            SubmitContactModification();
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
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
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

        public int GetNumberOfSearchResalts()
        {
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
