using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebDev.Models;
namespace WebDev.Controllers
{
    public class EventRegController : Controller
    {
        private myDBEntities db = new myDBEntities();
        // GET: EventReg
        public ActionResult Index()
        {
            ViewBag.EventName = new SelectList(db.events, "EventName", "EventName");
            ViewBag.Email = new SelectList(db.clients, "Email", "Email");
            return View();
        }
        public JsonResult getAllData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var clientdata = db.clients.ToList();
            var eventdata = db.events.ToList();
            var registerdata = db.registers.ToList();

            var final_records = from c in clientdata
                                join r in registerdata on c.Email equals r.Email
                                join e in eventdata on r.EventName equals e.EventName
                                orderby r.ID descending
                                select new eventListAll
                                {
                                    ID = r.ID,
                                    EventName = e.EventName,
                                    GuestNumber = r.GuestNumber,
                                    PaymentAmount = r.PaymentAmount,
                                    Email = c.Email,
                                    FullName = c.FullName,
                                    Phone = c.Phone,
                                    Date = e.Date,
                                    TicketFee = e.TicketFee

                                };
            return Json(final_records, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(register model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var DeleteRecord = db.registers.Where(x => x.EventName == model.EventName).Where(i => i.Email == model.Email).ToList();
                    if (DeleteRecord.Count() > 0)
                    {
                        TempData["duplicate"] = "Error: Event Data already registered under this client";
                        ViewBag.EventName = new SelectList(db.events, "EventName", "EventName");
                        ViewBag.Email = new SelectList(db.clients, "Email", "Email");
                        return View();
                        //return RedirectToAction("Index");
                    }
                    db.registers.Add(model);
                    db.SaveChanges();
                    ModelState.Clear();
                    TempData["msg"] = "Event Data registered successfully";
                    db.Dispose();
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