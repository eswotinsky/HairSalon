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

        [HttpPost("/client/delete/{clientId}/{stylistId}")]
        public ActionResult Delete(int clientId, int stylistId)
        {
            Client myClient = Client.Find(clientId);
            myClient.Delete();
            return RedirectToAction("Details", "Stylists", new {id=stylistId});
        }

        [HttpPost("/client/delete-all")]
        public ActionResult DeleteAll()
        {
            Client.DeleteAll();
            return View();
        }

        [HttpGet("/client/{id}")]
        public ActionResult Details(int id)
        {
            Client myClient = Client.Find(id);
            return View(myClient);
        }

        [HttpPost("/client/update/{clientId}")]
        public ActionResult Update(int clientId)
        {
            string name = Request.Form["new-client-name"];
            int stylistId = Int32.Parse(Request.Form["new-client-stylist"]);
            Client myClient = Client.Find(clientId);
            myClient.Edit(name, stylistId);
            return RedirectToAction("Details", new {id = clientId});
        }
    }
}
