using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class HomeController : BaseController
    {
        List<Product> product = new List<Product>();
        List<Category> categories = new List<Category>();
        CommenModel commen = new CommenModel();
        // GET: Home
        public ActionResult HomePage()
        {
            
            commen.Products = repo_product.List();
            commen.Categories = repo_category.List();
            product = repo_product.List();
            return View(commen);
        }
        //public PartialViewResult Category()
        //{
        //    categories = repo_category.List();
        //    commen.Categories = repo_category.List();
        //    return PartialView(commen);
        //}
        //public ActionResult ByCategory(int id)
        //{
        //    var cat = repo_category.List().Find(x => x.Id == id);
        //    var pro = repo_product.List().Find(x => x.CategoryID == id);
        //    var product = repo_product.List().Where(x => x.CategoryID == id).ToList();

        //    return View(product);
        //}
        public ActionResult GetProductDetail(int id)
        {
            var product = repo_product.List().Find(x => x.Id == id);
            //commen.Products = repo_product.List().Where(x => x.Id == id).ToList();
            //commen.ProductDetails = repo_productDetail.List().Where(x => x.Id == product.PDetailId).ToList();
            //commen.PDDetails = repo_pdDetail.List().Where(x => x.DetailID == product.PDetailId).ToList();
            return View(product);
        }

        public PartialViewResult ProductMiniShow()
        {

            product = repo_product.List();
            return PartialView(product);
        }

        public ActionResult ShowProduct(int id)
        {
            var pro = repo_product.Find(x => x.Id == id);
            return PartialView("_PartialProductDetail",pro);
        }
    }
}