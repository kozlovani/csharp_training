using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;
        private string middleName = "";
        private string nickName = "";
        private string photo = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homePage = "";
        private string bday = "-";
        private string bmonth = "-";
        private string byear = "";
        private string aday = "-";
        private string amonth = "-";
        private string ayear = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
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

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode(); // retuen 0 without optimization
        }

        public override string ToString()
        {
            return "FirstName=" + FirstName+", LastName="+LastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Home
        {
            get { return home; }
            set { home = value; }
        }

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        public string Work
        {
            get { return work; }
            set { work = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }

        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }
        public string HomePage
        {
            get { return homePage; }
            set { homePage = value; }
        }

        public string BDay
        {
            get { return bday; }
            set { bday = value; }
        }

        public string BMonth
        {
            get { return bmonth; }
            set { bmonth = value; }
        }

        public string BYear
        {
            get { return byear; }
            set { byear = value; }
        }

        public string ADay
        {
            get { return aday; }
            set { aday = value; }
        }

        public string AMonth
        {
            get { return amonth; }
            set { amonth = value; }
        }

        public string AYear
        {
            get { return ayear; }
            set { ayear = value; }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        public string Phone2
        {
            get { return phone2; }
            set { phone2 = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
    }
}
