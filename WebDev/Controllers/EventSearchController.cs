using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDev.Models;

namespace WebDev.Controllers
{
    public class EventSearchController : Controller
    {
        // GET: EventSearch
        public ActionResult Index(@event model)
        {
            model.date1 = DateTime.Today;
            model.date2 = DateTime.Today;
            return View(model);
        }



        public JsonResult GetAllList()
        {
            var myDb = new myDBEntities();
            myDb.Configuration.ProxyCreationEnabled = false;
            var eventList = myDb.events.Select(x => new ViewEvents
            {
                EventName = x.EventName,
                Description = x.Description,
                Location = x.Location,
                Date = x.Date,
                TicketFee = x.TicketFee
            }).ToList();
            return Json(eventList,JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetList_Date_Range(string date1, string date2)
        {
            //DateTime date1_val = Convert.ToDateTime(date1);
           // DateTime date2_val = Convert.ToDateTime(date2);
            var myDb = new myDBEntities();
            myDb.Configuration.ProxyCreationEnabled = false;
            string result = "SELECT * FROM event WHERE Date >= @d1 AND Date <= @d2";
            var data_range = myDb.events.SqlQuery(result, new SqlParameter("@d1", date1), new SqlParameter("@d2", date2)).ToList();
            return Json(data_range, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetList_EventOnly(string ename)
        {
            var myDb = new myDBEntities();
            myDb.Configuration.ProxyCreationEnabled = false;
            var eventList = myDb.events.Where(x => x.EventName.Contains(ename)).ToList();
            return Json(eventList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetList_EventandDate(string ename, string edate)
        {
            var myDb = new myDBEntities();
            myDb.Configuration.ProxyCreationEnabled = false;
            var eventList = myDb.events.Where(x => x.Date == edate).Where(x => x.EventName.Contains(ename)).ToList();
            return Json(eventList, JsonRequestBehavior.AllowGet);
        }
    }
}