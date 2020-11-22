using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDev.Models;

namespace WebDev.Controllers
{
    public class ClientRegController : Controller
    {
        // GET: ClientReg
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getAllData()
        {
            var myDb = new myDBEntities();
            myDb.Configuration.ProxyCreationEnabled = false;
            var clientList = myDb.clients.ToList();
            return Json(clientList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(client model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mydb = new myDBEntities();
                    if (mydb.clients.Any(exist => exist.Email == model.Email))
                    {
                        TempData["duplicate"] = "Duplicate Email found!, please recheck your client's email";
                        return View();
                    }

                    mydb.clients.Add(model);
                    mydb.SaveChanges();
                    ModelState.Clear();
                    TempData["msg"] = "Client data registred successfully!";
                    mydb.Dispose();
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["duplicate"] = "Something went wrong!, please verify your network connectivity";
                    return View();
                }

            }
            else
            {
                TempData["duplicate"] = "Inserted data not valid. Please recheck your data and register again";
                return View();
            }
            


        }
    }
}