using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests : IDisposable
    {

        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eric_swotinsky_test;";
        }

        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
        }

        [TestMethod]
        public void GetName_ReturnsStylistName_String()
        {
            string testName = "Bob";
            Stylist testStylist = new Stylist(testName);

            string result = testStylist.GetName();

            Assert.AreEqual(testName, result);
        }

        [TestMethod]
        public void GetAll_StylistsEmptyAtFirst_0()
       {
           int result = Stylist.GetAll().Count;
           Assert.AreEqual(0, result);
       }

        [TestMethod]
        public void Save_SavesStylistToDatabase_StylistList()
        {
            Stylist testStylist = new Stylist("Cindy");
            testStylist.Save();

            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist>{testStylist};

            CollectionAssert.AreEqual(testList, result);
        }



    }
}
