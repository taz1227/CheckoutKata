using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    public class Order
    {
        public string ItemSKU { get; set; }

        public int Quantity { get; set; }

        public Item Item { get; set;  }
    }
}
