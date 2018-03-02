// using System;
// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MySql.Data.MySqlClient;
// using HairSalon.Controllers;
// using HairSalon.Models;
//
// namespace HairSalon.Tests
// {
//     [TestClass]
//     public class SpecialtyControllerTest
//     {
//         [TestMethod]
//         public void Details_ReturnsCorrectView_True()
//         {
//             SpecialtyController controller = new SpecialtyController();
//             IActionResult actionResult = controller.Index();
//             ViewResult result = controller.Index() as ViewResult;
//             Assert.IsInstanceOfType(result, typeof(ViewResult));
//         }
//
//         [TestMethod]
//         public void Details_ReturnsCorrectModelType_Specialty()
//         {
//             SpecialtyController controller = new SpecialtyController();
//             IActionResult actionResult = controller.Index();
//             ViewResult indexView = controller.Index() as ViewResult;
//
//             var result = indexView.ViewData.Model;
//
//             Assert.IsInstanceOfType(result, typeof(Specialty);
//         }
//     }
// }
