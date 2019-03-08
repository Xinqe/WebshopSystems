namespace WebshopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
             public Order()
        {
     
        }

        public int ID { get; set; }

        public int AccountID { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; }
    }
}
