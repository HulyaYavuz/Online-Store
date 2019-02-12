using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart
        // GET: Sepet
        [HttpGet]
        public void AddBasket(int id, int size = 36, bool remove = false)
        {
            List<Cart> basket = null;
            if (Session["Basket"] == null)
            {
                basket = new List<Cart>();
                var pro = repo_product.Find(x => x.Id == id);
                if (pro != null)
                {
                    basket.Add(new Cart()
                    {
                        Count = 1,
                        Product = pro
                    });
                }
            }
            else
            {
                basket = (List<Cart>)Session["Basket"];
                if (basket.Any(x => x.Product.Id == id))
                {

                    var pro = basket.FirstOrDefault(x => x.Product.Id == id);
                    if (remove && pro.Count > 0)
                    {
                        pro.Count -= 1;
                    }
                    else
                    {
                        pro.Count += 1;
                    }

                }
                else
                {
                    var pro = repo_product.Find(x => x.Id == id);
                    if (pro != null)
                    {
                        basket.Add(new Cart()
                        {
                            Count = 1,
                            Product = pro
                        });
                    }
                }
            }
            Session["Basket"] = basket;
        }

        public void DeleteToBasketProduct(int id)
        {
            List<Models.Cart> basket = (List<Models.Cart>)Session["Basket"];
            if (basket != null)
            {
                if (id > 0)
                {
                    basket.RemoveAll(x => x.Product.Id == id);
                }
                else if (id == 0)
                {
                    basket.Clear();
                }
                Session["Basket"] = basket;
            }

        }

        public PartialViewResult MiniBasket()
        {
            if (HttpContext.Session["Basket"] != null)
                return PartialView(HttpContext.Session["Basket"]);
            else
                return PartialView();
        }

        public ActionResult MyCart()
        {
            List<Models.Cart> model = (List<Cart>)Session["Basket"];
            if (model == null)
            {
                model = new List<Models.Cart>();
            }
            var TotalPrice = model.Select(x => x.Product.Price.SalingPrice * x.Count).Sum();

            return View(model);
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(User _model, int? id)
        {
            var currentId = CurrentUserId();
            var customers = repo_user.Find(x => x.Id == currentId);
            //if (customers != null)
            //{
                customers.Name = _model.Name;
                customers.Surname = _model.Surname;
                customers.Phone = _model.Phone;
                customers.Email = _model.Email;
                customers.Adress = _model.Adress;
                repo_user.Update(customers);
            //}
            //else
            //{

            //}
            repo_user.Save();
            return RedirectToAction("Pay");
        }
        public ActionResult Pay()
        {
            return View();
        }
       

        public PartialViewResult HesapOzet()
        {
            if (HttpContext.Session["Basket"] != null)
                return PartialView(HttpContext.Session["Basket"]);
            else
                return PartialView();
        }
    }
}