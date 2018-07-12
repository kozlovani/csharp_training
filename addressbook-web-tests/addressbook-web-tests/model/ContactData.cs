using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allData;
        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (FirstName.CompareTo(other.FirstName) == 0)
            {
                return LastName.CompareTo(other.LastName);
            } else 
            {
                return FirstName.CompareTo(other.FirstName);
            } 
        }

        public override string ToString()
        {
            return "FirstName=" + FirstName+", LastName="+LastName;
        }

        public override int GetHashCode()
        {
            return (FirstName+ " "+LastName).GetHashCode();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string NickName { get; set; }

        public string Photo { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }
        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }
        public string HomePage { get; set; }

        public string BDay { get; set; }

        public string BMonth { get; set; }

        public string BYear { get; set; }

        public string ADay { get; set; }

        public string AMonth { get; set; }

        public string AYear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        public string Id { get; set; }
        public string AllPhones { get
            {
                if (allPhones != null)
                {
                    return allPhones;
                } else
                {
                    
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Phone2)).Trim();
                }
            }
            set { allPhones = value; } }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (AddEnter(Email) + AddEnter(Email2) + AddEnter(Email3)).Trim();
                }
            }
            set { allEmails = value; }
        }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    return (AddEnter(FirstName+ " "+ MiddleName + " "+ LastName) +
                        AddEnter(NickName) +
                        AddEnter(Title) + 
                        AddEnter(Company) + 
                        AddEnter(Address) +
                        AddEnter(AddTextBefore("H: ", Home)) +
                        AddEnter(AddTextBefore("M: ", Mobile)) +
                        AddEnter(AddTextBefore("W: ", Work)) +
                        AddEnter(AddTextBefore("F: ", Fax)) +
                        AddEnter(Email) +
                        AddEnter(Email2) +
                        AddEnter(Email3) +
                        AddEnter(AddTextBefore("Homepage:\r\n", HomePage)) +
                        AddEnter(AddTextBefore("Birthday ", getDate(BDay,BMonth,BYear))) +
                        AddEnter(AddTextBefore("Anniversary ", getDate(ADay, AMonth, AYear))) +
                        AddEnter(Address2) +
                        AddEnter(AddTextBefore("P: ",Phone2)) +
                        AddEnter(Notes)
                        ).Trim();
                }
            }
            set { allData = value; }
        }

        private string getDate(string day, string month, string year)
        {
            string date = "";
            if (!(day == null || day == "" || day == "-"))
            {
                date = day + ".";
            }
            if (!(month == null || month == "" || month == "-"))
            {
                date = date + " " + month;
            }
            if (!(year == null || year == "" || year == "-"))
            {
                date = date + " " + year;
            }
            return date;
        }

        private string AddTextBefore(string text, string field)
        {
            if (field == null || field == "")
            {
                return "";
            }
            else
            {
                return text+field;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone =="")
            {
                return "";
            } else
            {
                return Regex.Replace(phone, "[ -()]", "") + "\r\n";
            }
        }

        private string AddEnter(string str)
        {
            if (str == null || str == "")
            {
                return "";
            }
            else
            {
                return str + "\r\n";
            }
        }

    }
}
