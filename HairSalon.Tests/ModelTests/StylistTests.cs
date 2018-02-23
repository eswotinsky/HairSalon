using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests
    {

        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eric_swotinsky_test;";
        }

        [TestMethod]
        public void GetName_ReturnsStylistName_String()
        {
            string testName = "Bob";
            Stylist testStylist = new Stylist(testName);

            string result = testStylist.GetName();

            Assert.AreEqual(testName, result);
        }

    }
}
