using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Linq;

namespace WebAddressbookTests
{
    [Table (Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
        }

        public GroupData(string name)
        {
            Name = name;
        }

        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }

        public bool Equals(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public int CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode(); // retuen 0 without optimization
        }

        public override string ToString()
        {
            return "Name=" + Name + "\nheader="+Header+ "\nfooter=" + Footer;
        }

        [Column(Name="group_name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }

        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB()) { // for auto close DB at the end using
                return (from g in db.Groups select g).ToList();
            };
        }

        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB()) { // for auto close DB at the end using
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00") select c).Distinct().ToList();
            };
        }
    }

}
