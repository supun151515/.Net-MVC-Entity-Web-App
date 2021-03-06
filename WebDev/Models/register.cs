//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class register
    {
        public int ID { get; set; }
        [DisplayName("Event Name")]
        [DefaultValue("--Select--")]
        [Required(ErrorMessage = "Please select a Event Name")]
        public string EventName { get; set; }
        [DisplayName("Guest Number")]
        [Required(ErrorMessage = "Guest Number required!")]
        [Range(1, 999999999999, ErrorMessage = "Should be a integer value and limited to 12 numbers")]
        public int GuestNumber { get; set; }
        [DisplayName("Payment Amount")]
        [Required(ErrorMessage = "Payment Amount required!")]
        [Range(1, 999999999999, ErrorMessage = "Payment Amount should be a currency value!")]
        public Nullable<double> PaymentAmount { get; set; }
        [DefaultValue("--Select--")]
        [Required(AllowEmptyStrings=false,ErrorMessage = "Email required!")]
        [DisplayName("Email")]
        public string Email { get; set; }
    
        public virtual client client { get; set; }
        public virtual @event @event { get; set; }
    }
}
