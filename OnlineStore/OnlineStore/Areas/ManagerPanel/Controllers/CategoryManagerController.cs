using OnlineStore.Controllers;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Areas.ManagerPanel.Controllers
{
    public class CategoryManagerController : BaseController
    {
        // GET: ManagerPanel/CategoryManager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryOperations(int id = 0)
        {
            ViewBag.Product = new SelectList(repo_category.List().Where(x => x.Root == 0), "Id", "Title");

            return View();
        }
        [HttpPost]
        public ActionResult CategoryOperations(Category category,int? id)
        {
            if(id != null)
            {
                var catid = repo_category.List().Find(x => x.Id == id);
                return View(catid);
            }
           
            if (category != null)
            {
                category.Title = category.Title;
                category.Root = category.Root;
               
                repo_category.Insert(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
          
           
        }
        [HttpGet]
        public ActionResult ProductCodeFilter()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult ProductCodeFilter(string productCode)
        {
            var code = repo_product.List().Where(x => x.ProductCode == productCode).ToList();
            return View(code);
        }
        public ActionResult BrandFilter()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult BrandFilter(string brand)
        {
            var filter = repo_product.List().Where(x => x.Brand.Name == brand).ToList();
            return View(filter);
        }
        public ActionResult CategoryFilter()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CategoryFilter(string category)
        {
            var filter = repo_product.List().Where(x => x.Category.Title == category).ToList();
            return View(filter);
        }

    }
}