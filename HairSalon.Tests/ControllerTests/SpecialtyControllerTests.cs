using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtiesControllerTest
    {
        [TestMethod]
        public void Details_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            IActionResult actionResult = controller.Details(1);
            ViewResult result = controller.Details(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_ReturnsCorrectModelType_Specialty()
        {
            SpecialtiesController controller = new SpecialtiesController();
            IActionResult actionResult = controller.Details(1);
            ViewResult indexView = controller.Details(1) as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(Specialty));
        }
    }
}
