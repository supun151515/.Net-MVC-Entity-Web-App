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
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            this.registers = new HashSet<register>();
        }

        [DisplayName("Client Name")]
        [Required(ErrorMessage = "Client Name required!")]
        [StringLength(25, ErrorMessage = "Maximum 25 characters exceeded")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Age required!")]
        //  [MaxLength(2, ErrorMessage = "Maximum 2 characters exceeded")]
        [Range(16, 99, ErrorMessage = "Invalid age!, please recheck")]
        public int Age { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email required!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        [StringLength(35, ErrorMessage = "Maximum 35 characters exceeded")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address required!")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters exceeded")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone number required!")]
        [DisplayName("Phone number")]
        [StringLength(15, ErrorMessage = "Maximum 15 characters exceeded")]
        public string Phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<register> registers { get; set; }
    }
}