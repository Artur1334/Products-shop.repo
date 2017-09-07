namespace EntitieServices.EntitiProductShop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentID { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
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

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
