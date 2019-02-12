using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class CategoryController : BaseController
    {
        List<Product> product = new List<Product>();
        List<Category> categories = new List<Category>();
        CommenModel commen = new CommenModel();
        // GET: Category

        public PartialViewResult Category()
        {
            categories = repo_category.List();
            commen.Categories = repo_category.List();
            return PartialView(commen);
        }

        public ActionResult ByCategory(int id,Product pro)
        {
            var cat = repo_category.List().Find(x => x.Id == id);
            //var pro = repo_product.List().Find(x => x.CategoryID == id);
            var product = repo_product.List().Where(x => x.Category_Id == id).ToList();
            var filter_pro = repo_product.List().FindAll(x => x.Category_Id == pro.Category_Id);

            if (product.Count == 0 || product == null)
            {
                return View(filter_pro);
            }
            else
            {
                return View(product);
            }

        }

        public ActionResult BySizeFilter(int id)
        {

           
            var prod = repo_product.List().Find(x => x.ProductDetails.First().Properties == id.ToString());
            var pro = repo_product.List().FindAll(x => x.ProductDetails.First().Properties == id.ToString());
            return RedirectToAction("ByCategory", pro);
        }
    }
}