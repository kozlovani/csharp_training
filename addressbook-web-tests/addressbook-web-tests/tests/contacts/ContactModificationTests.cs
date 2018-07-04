using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {


            //preparate
            if (app.Contacts.GetContactList().Count == 0)
            {
                app.Contacts.Create(new ContactData("",""));
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //action
            ContactData newData = new ContactData("Update FirstName", "Update LastName");
            newData.MiddleName = "Update MiddleName";
            app.Contacts.Modify(0, newData);

            //varification
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}