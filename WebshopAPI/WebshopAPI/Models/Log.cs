namespace WebshopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class Log
    {
        public int ID { get; set; }


        public string Description { get; set; }
    }
}
