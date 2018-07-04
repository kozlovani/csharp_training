using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            //preparate
            ContactData contact = new ContactData("Ivan", "Ivanov");
            contact.MiddleName = "Ivanovich";
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //action
            app.Contacts.Create(contact);

            //varification
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            
            
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            //preparate
            ContactData contact = new ContactData("", "");
            contact.MiddleName = "";
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //action
            app.Contacts.Create(contact);

            //varification
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
