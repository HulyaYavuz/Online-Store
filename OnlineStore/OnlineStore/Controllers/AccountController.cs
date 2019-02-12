using OnlineStore.Mail;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                var mail = repo_user.List().Find(x => x.Email == user.Email);
                if (mail != null)
                {
                    throw new Exception("Zaten bu e-posta kayıtlıdır.");
                }
                else
                {
                    user.RolID = 1;
                    repo_user.Insert(user);
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                ViewBag.reError = ex.Message;
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            try
            {
                var user = repo_user.List().Find(x => x.Phone == model.Phone && x.Email == model.Email);
                if (user != null)
                {
                    Session["LogonUser"] = user;
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    ViewBag.reError = "Kullanıcı bilgileriniz yanlış";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.reError = ex.Message;
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["LogonUser"] = null;
            return RedirectToAction("Login", "Account");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            var member = repo_user.List().Find(x => x.Email == email);
            if (member == null)
            {
                ViewBag.MyError = "Böyle bir hesap bulunamadı.";
                return View();
            }
            else
            {
                var body = "Şifreniz : " + member.Phone;
                MyMail mail = new MyMail(member.Email, "Şifremi Unuttum", body);
                mail.SendMail();
                TempData["Info"] = email + " mail adresinize şifreniz gönderilmiştir.";
                return RedirectToAction("Login");
            }

        }

    }
}