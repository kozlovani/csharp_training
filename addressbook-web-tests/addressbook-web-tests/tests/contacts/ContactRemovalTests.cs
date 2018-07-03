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
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            if (oldContacts.Count == 0)
            {
                app.Contacts.Create(new ContactData("", ""));
            }

            //action
            app.Contacts.Remove(1);

            //varification
        }

    }
}