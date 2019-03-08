namespace WebshopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {

        public Account()
        {
          
        }

        public int ID { get; set; }

     
        public string Username { get; set; }

      
        public string Password { get; set; }


    }
}
