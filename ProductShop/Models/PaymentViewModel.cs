using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductShop.Models
{
    public class PaymentViewModel
    {
        public int PaymentID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Address")]
        public string CustomerAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        [Display(Name = "State")]
        public string CustomerState { get; set; }

        [StringLength(100)]

        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstNAme { get; set; }

        [Required]
        [StringLength(50)]
        public string LastNAme { get; set; }

        public DateTime? OrderDate { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }
        public decimal Total { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

       
        
    }
}