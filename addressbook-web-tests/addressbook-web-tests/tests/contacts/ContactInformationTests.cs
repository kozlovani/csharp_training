﻿using NUnit.Framework;

namespace WebAddressbookTests
{
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest() {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
    }
}
