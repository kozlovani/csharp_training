using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS) { 
                List<ContactData> fromUi = app.Contacts.GetContactList();
                List<ContactData> fromDb = ContactData.GetAll();
                fromUi.Sort();
                fromDb.Sort();
                Assert.AreEqual(fromUi, fromDb);
            }
        }

    }
}
