using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDev.Models
{
    public class eventListAll
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        public int GuestNumber { get; set; }
        public Nullable<double> PaymentAmount { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Date { get; set; }
        public double TicketFee { get; set; }
    }
}