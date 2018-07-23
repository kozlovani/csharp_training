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
            if (app.Contacts.GetContactCount() == 0)
            {
                app.Contacts.Create(new ContactData("firstname_1", "lastname_1"));
            }
            if (app.Groups.GetGroupCount() == 0)
            {
                app.Groups.Create(new GroupData("name_test"));
            }
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count() == 0)
            {
                app.Contacts.AddContactToGroup(ContactData.GetAll()[0], group);
                oldList = group.GetContacts();
            }
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
