using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            //preparate
            
            if (app.Contacts.GetContactList().Count == 0)
            {
                app.Contacts.Create(new ContactData("", ""));
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //action
            app.Contacts.Remove(0);

            //varification
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContact);
        }

    }
}