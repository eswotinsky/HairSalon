using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTests : IDisposable
    {
        public SpecialtyTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eric_swotinsky_test;";
        }

        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        [TestMethod]
        public void GetName_ReturnsSpecialtyName_String()
        {
            string testName = "Highlights";
            Specialty testSpecialty = new Specialty(testName);

            string result = testSpecialty.GetName();

            Assert.AreEqual(testName, result);
        }

        [TestMethod]
        public void Save_SavesSpecialtyToDatabase_SpecialtyList()
        {
            Specialty testSpecialty = new Specialty("Highlights");
            testSpecialty.Save();

            List<Specialty> result = Specialty.GetAll();
            List<Specialty> testList = new List<Specialty>{testSpecialty};

            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Delete_DeletesSpecialtyFromDatabase_SpecialtyList()
        {
            Specialty testSpecialty = new Specialty("Highlights");
            testSpecialty.Save();

            List<Specialty> testList = new List<Specialty>{testSpecialty};
            testSpecialty.Delete();
            List<Specialty> result = Specialty.GetAll();

            CollectionAssert.AreEqual(testList, result);
        }

        // [TestMethod]
        // public void Delete_DeletesSpecialtyAssociationsFromDatabase_SpecialtyList()
        // {
        //     //delete corresponding rows from join table
        // }

        [TestMethod]
        public void Find_FindsSpecialtyInDatabase_Specialty()
        {
            Specialty testSpecialty = new Specialty("Highlights");
            testSpecialty.Save();

            Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());

            Assert.AreEqual(testSpecialty, foundSpecialty);
        }

        [TestMethod]
        public void GetStylists_ReturnsStylistsWithGivenSpecialty_StylistList()
        {
            Specialty testSpecialty = new Specialty("Highlights");
            testSpecialty.Save();

            Stylist testStylist = new Stylist("Cindy");
            testStylist.Save();

            testStylist.AddSpecialty(testSpecialty);
            List<Specialty> result = testStylist.GetSpecialties();
            List<Specialty> testList = new List<Specialty> {testSpecialty};

            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void GetAll_SpecialtiesEmptyAtFirst_0()
        {
            int result = Specialty.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllSpecialties_SpecialtyList()
        {
            string specialty1 = "Highlights";
            string specialty2 = "Waxing";

            Specialty newSpecialty1 = new Specialty(specialty1);
            Specialty newSpecialty2 = new Specialty(specialty2);

            newSpecialty1.Save();
            newSpecialty2.Save();

            List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };
            List<Specialty> result = Specialty.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }
    }
}
