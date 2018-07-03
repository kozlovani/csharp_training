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
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            if (oldContacts.Count == 0)
            {
                app.Contacts.Create(new ContactData("",""));
            }

            //action
            ContactData newData = new ContactData("Update FirstName", "Update LastName");
            newData.MiddleName = "Update MiddleName";
            app.Contacts.Modify(1, newData);

            //varification

        }
    }
}