using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class RemovingContactsFromGroupTests : AuthTestBase
    {

        [Test] 
        public void RemovingContactsFromGroupTest()
        {
            //preperate
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.First();

            //action
            app.Contacts.RemoveContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            //varification
            Assert.AreEqual(oldList, newList);

        }
    }
}
