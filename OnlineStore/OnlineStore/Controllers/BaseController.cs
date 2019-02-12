using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class BaseController : Controller
    {
        public Repository<Product> repo_product = new Repository<Product>();
        public Repository<Category> repo_category = new Repository<Category>();
        public Repository<User>  repo_user = new Repository<User>();
        public Repository<ProductDetail> repo_productDetail = new Repository<ProductDetail>();
        public Repository<Price> repo_price = new Repository<Price>();

        public BaseController()
        {

        }

        protected User CurentUser()
        {
            return (User)Session["LogonUser"];
        }
        protected int CurrentUserId()
        {
            return /*((User)Session["LogonUser"]).Id;*/ 2;
        }
        protected bool IsLogon()
        {
            if (Session["LogonUser"] == null)
                return false;
            else
                return true;
        }
    }
}