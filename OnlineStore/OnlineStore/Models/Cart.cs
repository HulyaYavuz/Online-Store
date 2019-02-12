using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class Cart
    {
        public Product Product { get; set; }

        public Price Price { get; set; }

        public int Count { get; set; }

    }
}