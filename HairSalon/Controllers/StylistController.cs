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
    }
}
