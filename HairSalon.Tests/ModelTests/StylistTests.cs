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
        public void GetAll_ReturnsAllStylists_StylistList()
        {
            string name01 = "Cindy";
            string name02 = "Bob";

            Stylist newStylist01 = new Stylist(name01, 1);
            Stylist newStylist02 = new Stylist(name02, 1);

            newStylist01.Save();
            newStylist02.Save();

            List<Stylist> newList = new List<Stylist> { newStylist01, newStylist02 };
            List<Stylist> result = Stylist.GetAll();
            CollectionAssert.AreEqual(newList, result);
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

        [TestMethod]
        public void GetClients_RetrievesAllClientsBelongingToStylist_ClientList()
        {
            Stylist testStylist = new Stylist("Cindy", 1);
            testStylist.Save();

            Client newClient01 = new Client("Bob", testStylist.GetId(), 1);
            newClient01.Save();
            Client newClient02 = new Client("Bill", testStylist.GetId(), 2);
            newClient02.Save();

            List<Client> testClientList = new List<Client> {newClient01, newClient02};
            List<Client> resultClientList = testStylist.GetClients();

            CollectionAssert.AreEqual(testClientList, resultClientList);
        }

        [TestMethod]
        public void Find_FindsStylistInDatabase_Stylist()
        {
            Stylist testStylist = new Stylist("Cindy");
            testStylist.Save();

            Stylist foundStylist = Stylist.Find(testStylist.GetId());

            Assert.AreEqual(testStylist, foundStylist);
        }
    }
}
