using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDev.Models;

namespace WebDev.Controllers
{
    public class EventDeleteController : Controller
    {
        // GET: EventDelete
        private myDBEntities myDB = new myDBEntities();
        public ActionResult Index()
        {
            ViewBag.EventName = new SelectList(myDB.events, "EventName", "EventName");
            ViewBag.Email = new SelectList(myDB.clients, "Email", "Email");
            //ViewBag.EventNames = myDB.events.ToList();
            return View();
        }
        public JsonResult GetEmails(string eName)
        {
            myDB.Configuration.ProxyCreationEnabled = false;
            var eventList = myDB.registers.Where(x => x.EventName == eName).OrderBy(i=>i.Email).ToList();
            return Json(eventList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEvents(string email)
        {
            myDB.Configuration.ProxyCreationEnabled = false;
            var eventList = myDB.registers.Where(x => x.Email == email).OrderBy(i => i.EventName).ToList();
            return Json(eventList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getAllData()
        {
            myDB.Configuration.ProxyCreationEnabled = false;
            var clientdata = myDB.clients.ToList();
            var eventdata = myDB.events.ToList();
            var registerdata = myDB.registers.ToList();

            var final_records = from c in clientdata
                                join r in registerdata on c.Email equals r.Email
                                join e in eventdata on r.EventName equals e.EventName
                                orderby e.Date

                                select new eventListAll
                                {
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
        [ValidateAntiForgeryToken]
        public ActionResult Index(register model)
        {
             try
                {
                var DeleteRecord = myDB.registers.Where(x => x.EventName == model.EventName).Where(i => i.Email == model.Email).ToList();
                foreach(var i in DeleteRecord)
                {
                    myDB.registers.Remove(i);
                }
                //myDB.registers.Remove(DeleteRecord);
                myDB.SaveChanges();
                ModelState.Clear();
                TempData["msg"] = "Event data deleted successfully!";
               // myDB.Dispose();
                return RedirectToAction("Index");
                }
                catch
                {
                    TempData["duplicate"] = "Something went wrong!, please verify data provided or contact your system administrator";
                    myDB.Dispose();
                    return RedirectToAction("Index");
            }
        }
        }

}