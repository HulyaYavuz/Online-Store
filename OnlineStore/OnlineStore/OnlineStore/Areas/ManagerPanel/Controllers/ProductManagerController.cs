using OnlineStore.Controllers;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Areas.ManagerPanel.Controllers
{
    public class ProductManagerController : BaseController
    {
        // GET: ManagerPanel/ProductManager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProduct()
        {
            List<Product> products = new List<Product>();
            products = repo_product.List();
            return View(products);
        }
       
        public ActionResult GetSubCategory(int? categoryId)
        { 
            //Get SubCategory for dropdownlist in AddToProduct 
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var sub in repo_category.List().Where(x => x.Root == categoryId))
            {
                result.Add(new SelectListItem
                {
                    Text = sub.Title.ToString(),
                    Value = sub.Id.ToString()
                });
            }
           var altkategoriler = result;
            ViewBag.Product = new SelectList(repo_category.List().Where(x => x.Root == 0), "Id", "Title");

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddToProduct(int id = 0)
        {
            ViewBag.Product = new SelectList(repo_category.List().Where(x => x.Root == 0), "Id", "Title");

            return View();
        }
        [HttpPost]
        public ActionResult AddToProduct(Product product)
        {
            var productImagePath = string.Empty;
            var cat_id = repo_category.List().Find(x => x.Root == product.Category.Root && x.Title == product.Category.Title);
            var price_id = repo_price.List().Find(x => x.SalingPrice == product.Price.SalingPrice && x.BuyingPrice == product.Price.BuyingPrice && x.KDV == product.Price.KDV).Id;
            var id = cat_id.Id;
            product.Category = null;

           // product.Category.Id = id;
            //change the image's path
            if (Request.Files != null && Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file.ContentLength > 0)
                {
                    var folder = Server.MapPath("~/img/product-img");
                    var filename = Guid.NewGuid() + ".jpg";
                    file.SaveAs(Path.Combine(folder, filename));

                    var filePath = "img/product-img/" + filename;
                    productImagePath = filePath;
                }
            }
           
            if (product != null)
            {
                
                    //Add product
                    //TODO: id null ise category ekleye yönlendirme
                   // product.CategoryID = id;
                    product.Category_Id = id;
                    product.Name = product.Name;
                    product.Stock = product.Stock;
                    product.ImageName = productImagePath;
                    if (price_id != 0)
                    {
                        product.Price.BuyingPrice = product.Price.BuyingPrice;
                        product.Price.KDV = product.Price.KDV;
                        product.Price.SalingPrice = product.Price.SalingPrice;
                    }
                    else
                    {
                        product.Price = null;
                        product.Price_Id = price_id;
                    }
                    repo_product.Insert(product);
                
            }
            ViewBag.Product = new SelectList(repo_category.List().Where(x => x.Root == 0), "Id", "Title");
          
            return RedirectToAction("GetProduct");
        }

        public ActionResult EditToProduct(int id = 0)
        {
            var product = repo_product.Find(x => x.Id == id);
            ViewBag.Product = new SelectList(repo_category.List().Where(x => x.Root == 0), "Id", "Title");
            return View(product);
        }
        [HttpPost]
        public ActionResult EditToProduct(Product product)
        {
            var cat_id = repo_category.List().Find(x => x.Root == product.Category.Root && x.Title == product.Category.Title);
            var productImagePath = string.Empty;
            //change the image's path
            if (Request.Files != null && Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file.ContentLength > 0)
                {
                    var folder = Server.MapPath("~/img/product-img");
                    var filename = Guid.NewGuid() + ".jpg";
                    file.SaveAs(Path.Combine(folder, filename));

                    var filePath = "img/product-img/" + filename;
                    productImagePath = filePath;
                }
            }


            if (product != null)
            {
                
                //TODO: Update product 
                var dbProduct = repo_product.Find(x => x.Id == product.Id);
                if (string.IsNullOrEmpty(productImagePath) == false)
                {
                    dbProduct.ImageName = productImagePath;
                }
                dbProduct.Name = product.Name;
                dbProduct.Stock = product.Stock;

                if(cat_id == null)
                {
                    dbProduct.Category_Id = product.Category.Id;
                    product.Category = null;
                }
                else
                {
                    dbProduct.Category_Id = cat_id.Id;
                    product.Category = null;
                }
                dbProduct.Price.KDV = product.Price.KDV;
                dbProduct.Price.BuyingPrice = product.Price.BuyingPrice;
                dbProduct.Price.SalingPrice = product.Price.SalingPrice;
                }
            repo_product.Save();
            ViewBag.Product = new SelectList(repo_category.List().Where(x => x.Root == 0), "Id", "Title");
            return RedirectToAction("GetProduct");
        }

        public ActionResult Delete(int id)
        {
            var not = repo_product.Find(x => x.Id == id);
            repo_product.Delete(not);
            repo_product.Save();
            return RedirectToAction("GetProduct");
        }
    }
}