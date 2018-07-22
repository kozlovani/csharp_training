using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {


            //preparate
            if (app.Contacts.GetContactCount() == 0)
            {
                app.Contacts.Create(new ContactData("",""));
            }
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];

            //action
            ContactData newData = new ContactData("Update FirstName", "Update LastName");
            newData.Id = oldData.Id;
            newData.MiddleName = "Update MiddleName";
            app.Contacts.Modify(newData);

            //varification
            app.Navigator.GoToHomePage();
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }
        }
    }
}