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
            if (ContactData.GetAll().Except(oldList).Count() == 0)
            {
                app.Contacts.Create(new ContactData("firstname_2", "lastname_2"));
            }
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
