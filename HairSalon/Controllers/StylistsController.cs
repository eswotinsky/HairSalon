using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylist/add")]
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

        [HttpPost("/stylist/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Stylist myStylist = Stylist.Find(id);
            myStylist.Delete();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("/stylist/update/{stylistId}")]
        public ActionResult Update(int stylistId)
        {
            string name = Request.Form["new-stylist-name"];
            Stylist myStylist = Stylist.Find(stylistId);
            myStylist.Edit(name);
            return RedirectToAction("Details", new {id = stylistId});
        }
    }
}
