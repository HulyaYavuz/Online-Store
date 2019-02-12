using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class CommenModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }
}