using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTests : IDisposable
    {

        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eric_swotinsky_test;";
        }

        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
        }

        [TestMethod]
        public void GetName_ReturnsClientName_String()
        {
            string testName = "Bob";
            Client testClient = new Client(testName, 1);

            string result = testClient.GetName();

            Assert.AreEqual(testName, result);
        }

        [TestMethod]
        public void GetAll_ClientsEmptyAtFirst_0()
        {
           int result = Client.GetAll().Count;
           Assert.AreEqual(0, result);
        }

        [TestMethod]
         public void GetAll_ReturnsAllClients_ClientList()
         {
             string name01 = "Cindy";
             string name02 = "Bob";

             Client newClient01 = new Client(name01, 1, 0);
             Client newClient02 = new Client(name02, 1, 1);

             newClient01.Save();
             newClient02.Save();

             List<Client> newList = new List<Client> { newClient01, newClient02 };
             List<Client> result = Client.GetAll();
             CollectionAssert.AreEqual(newList, result);
         }

         [TestMethod]
         public void Save_SavesClientToDatabase_ClientList()
         {
             Client testClient = new Client("Steve", 1);
             testClient.Save();

             List<Client> testList = new List<Client>{testClient};
             List<Client> result = Client.GetAll();

             CollectionAssert.AreEqual(testList, result);
         }

         [TestMethod]
         public void Delete_DeletesClientFromDatabase_ClientList()
         {
             Client testClient1 = new Client("Steve", 1);
             testClient1.Save();

             Client testClient2 = new Client("Bob", 1);
             testClient2.Save();

             List<Client> testList = new List<Client>{testClient1};
             testClient2.Delete();
             List<Client> result = Client.GetAll();

             CollectionAssert.AreEqual(testList, result);
         }

         [TestMethod]
         public void Edit_ChangesClientNameAndStylistId_Client()
         {
             Client testClient = new Client("Steve", 1);
             testClient.Save();

             string newName = "Bob";
             testClient.Edit(newName, 2);
             Client foundClient = Client.Find(testClient.GetId());

             Assert.AreEqual(testClient, foundClient);
         }
    }
}
