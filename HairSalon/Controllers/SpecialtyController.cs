using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {
        [HttpGet("/specialty/add")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/specialty/create")]
        public ActionResult Create()
        {
            string formName = Request.Form["new-specialty-name"];
            Specialty newSpecialty = new Specialty(formName);
            newSpecialty.Save();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("/specialty/{id}")]
        public ActionResult Details(int id)
        {
            Specialty mySpecialty = Specialty.Find(id);
            return View(mySpecialty);
        }
    }
}
