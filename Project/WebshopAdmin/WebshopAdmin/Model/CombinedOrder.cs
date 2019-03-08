using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopAdmin.Model
{
    public class CombinedOrder
    {

        public Account account { get; set; }
        public Order order { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public List<Product> products { get; set; }

        public CombinedOrder()
        {
            orderItems = new List<OrderItem>();
            products = new List<Product>();
        }

    }
}
