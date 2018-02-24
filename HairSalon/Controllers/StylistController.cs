using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        [HttpGet("/stylist/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpGet("/stylist/{id}")]
        public ActionResult Details(int id)
        {
            Stylist myStylist = Stylist.Find(id);
            return View(myStylist);
        }

        [HttpPost("/stylist/delete-all")]
        public ActionResult Delete()
        {
            Stylist.DeleteAll();
            return View("DeleteAll");
        }

        [HttpPost("/stylist/create")]
        public ActionResult Create()
        {
            string formName = Request.Form["new-stylist-name"];
            Stylist newStylist = new Stylist(formName);
            newStylist.Save();
            return View("Details", newStylist);
        }
    }
}
