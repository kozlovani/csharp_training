﻿using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("z");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Modify(1, newData);
        }
    }
}