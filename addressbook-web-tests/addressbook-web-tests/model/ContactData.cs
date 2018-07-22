using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
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

        [Column(Name ="deprecated")]
        public string Deprecated { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        [Column(Name = "photo")]
        public string Photo { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string Home { get; set; }

        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "work")]
        public string Work { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string HomePage { get; set; }

        [Column(Name = "bday")]
        public string BDay { get; set; }

        [Column(Name = "bmonth")]
        public string BMonth { get; set; }

        [Column(Name = "byear")]
        public string BYear { get; set; }

        [Column(Name = "aday")]
        public string ADay { get; set; }

        [Column(Name = "amonth")]
        public string AMonth { get; set; }

        [Column(Name = "ayear")]
        public string AYear { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
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

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            { // for auto close DB at the end using
                return (from c in db.Contacts.Where(x => x.Deprecated =="0000-00-00 00:00:00") select c).ToList();
            };
        }

    }
}
