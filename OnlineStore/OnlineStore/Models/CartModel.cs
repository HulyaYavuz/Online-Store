using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class CartModel
    {
        public CartModel()
        {
            Product = new Dictionary<int, int>();
            Price = new Dictionary<int, int>();

        }

        public Dictionary<int, int> Product { get; }
        public Dictionary<int, int> Price { get; }
    }
    
}