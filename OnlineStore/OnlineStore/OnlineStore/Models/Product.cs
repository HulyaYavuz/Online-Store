using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProductCode { get; set; }

        public string ImageName { get; set; }

        public Nullable<int> Stock { get; set; }

      //  public Nullable<int> CategoryID { get; set; }

        public Nullable<int> Category_Id { get; set; }

        public Nullable<int> Price_Id { get; set; }

        public Nullable<int> Image_Id { get; set; }

        public Nullable<int> OrderID { get; set; }

        public Nullable<int> Brand_Id { get; set; }

        [ForeignKey("Category_Id")]
        public virtual  Category Category { get; set; }

        [ForeignKey("Brand_Id")]
        public virtual Brand Brand { get; set; }

        [ForeignKey("Price_Id")]
        public virtual Price Price { get; set; }

        [ForeignKey("Image_Id")]
        public virtual Image Image { get; set; }

        public virtual List<ProductDetail> ProductDetails { get; set; }
        
    }
}