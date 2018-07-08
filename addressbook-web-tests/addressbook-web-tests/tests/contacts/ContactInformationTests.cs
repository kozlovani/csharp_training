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
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void ContactInformationDetailsTest()
        {
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetailsForm(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromDetails.AllData, fromForm.AllData);
        }
    }
}
