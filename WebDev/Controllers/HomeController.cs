using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDev.Models;
namespace WebDev.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var myDb = new myDBEntities();
            var dateNow = DateTime.Now.ToString("yyyy/MM/dd");
            myDb.Configuration.ProxyCreationEnabled = false;
            string result = "SELECT TOP 9 * FROM event WHERE Date >= @d1 ORDER BY Date";
            var data_range = myDb.events.SqlQuery(result, new SqlParameter("@d1", dateNow)).ToList();
            ViewBag.LatestEvents = data_range;
            return View();
        }
    }
}