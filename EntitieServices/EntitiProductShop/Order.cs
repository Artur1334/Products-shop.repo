namespace EntitieServices.EntitiProductShop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        public int OrderItemID { get; set; }

        public int PaymentId { get; set; }

        public int ProductId { get; set; }

        public decimal? ProductQuantity { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
