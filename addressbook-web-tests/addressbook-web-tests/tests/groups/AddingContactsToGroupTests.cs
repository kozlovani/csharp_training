using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class AddingContactsToGroupTests : AuthTestBase
    {

        [Test] 
        public void AddingContactToGroupTest()
        {
            //preperate
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            //action
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            //varification
            Assert.AreEqual(oldList, newList);

        }
    }
}
