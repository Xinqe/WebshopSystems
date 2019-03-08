namespace WebshopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
   
        public Product()
        {

        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

     
    }
}
