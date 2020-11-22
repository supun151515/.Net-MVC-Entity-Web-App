using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDev.Models;

namespace WebDev.Controllers
{
    public class ClientEditController : Controller
    {
        // GET: ClientEdit
        private myDBEntities myDB = new myDBEntities();
        public ActionResult Index()
        {
            ViewBag.Email = new SelectList(myDB.clients, "Email", "Email");
            return View();
        }

        public JsonResult GetClients(string email)
        {
            myDB.Configuration.ProxyCreationEnabled = false;
            var eventList = myDB.clients.Where(x => x.Email == email).ToList();
            return Json(eventList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Address, string Phone, string Email, double PaymentAmount)
        {
            try
            {
                var updateRecord = myDB.clients.Where(x => x.Email == Email).FirstOrDefault();
                if(updateRecord != null)
                {
                    var updateregister = myDB.registers.Where(x => x.Email == updateRecord.Email).FirstOrDefault();
                    if(updateregister != null)
                    {
                        updateregister.PaymentAmount = PaymentAmount;
                        myDB.SaveChanges();

                    }
                    /// myDB.clients.Attach(updateRecord);
                    //updateRecord.Address = model.Address;
                    //updateRecord.Phone = model.Phone;
                    //  myDB.Entry(updateRecord).State = EntityState.Modified;
                    
                    myDB.SaveChanges();
                    ModelState.Clear();
                    TempData["msg"] = "Client data updated successfully!";
                   // myDB.Dispose();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["duplicate"] = "Something went wrong!, please verify your network connectivity";
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                TempData["duplicate"] = "Something went wrong!, please verify your network connectivity";
                return RedirectToAction("Index");
            }
        }

    }
}