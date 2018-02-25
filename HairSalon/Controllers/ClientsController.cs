using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {

        [HttpGet("/client/add/{stylistId}")]
        public ActionResult CreateForm(int stylistId)
        {
            Stylist myStylist = Stylist.Find(stylistId);
            return View(myStylist);
        }

        [HttpPost("/client/create")]
        public ActionResult Create()
        {
            string formName = Request.Form["new-client-name"];
            int stylistId = Int32.Parse(Request.Form["stylistId"]);
            Client newClient = new Client(formName, stylistId);
            newClient.Save();
            return RedirectToAction("Details", "Stylists", new {id=stylistId});
        }
    }
}
