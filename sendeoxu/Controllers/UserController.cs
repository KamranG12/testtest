using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sendeoxu.Models;
using System.Web.Helpers;

namespace sendeoxu.Controllers
{
    public class UserController : Controller
    {
        private FirstProjectEntities db = new FirstProjectEntities();
        [HttpPost]
        public JsonResult Login(string email,string password)
        {
            if (email!=null && password!=null)
            {            
                 var pass = Crypto.Hash(password, "MD5");
                User user = db.Users.FirstOrDefault(u => u.email == email&&u.password==pass);
                
                if (user!=null)
                {
                    Session["user"] = true;
                    Session["user_name"] = user.fullname;
                    Session["user_id"] = user.id;
                    var response = true;
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var response = false;
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
               
            }
            else
            {
                var response = false;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Registration(User user)
        {
           // return Content(user.fullname);
            if (user.email != null && user.password != null && user.fullname != null)
            {
                user.password = Crypto.Hash(user.password, "MD5");
                User usr = db.Users.FirstOrDefault(u => u.email == user.email);
                if (usr == null)
                {
                    user.reytinq = 0;
                    db.Users.Add(user);
                    db.SaveChanges();
                    Session["user"] = true;
                    Session["user_name"] = user.fullname;
                    Session["user_id"] = user.id;
                    var response = true;
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var response = false;
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var response = false;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult checkEmail(string email)
        {
            if (email.Length > 0)
            {
                User user = db.Users.FirstOrDefault(usr => usr.email == email);
                if (user != null)
                {
                    var response = new
                    {
                        valid = false,
                        message = "This email already exists!"
                    };
                    return Json(response, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    var response = new
                    {
                        valid = true,
                    };
                    return Json(response, JsonRequestBehavior.AllowGet);

                }

            }
            else
            {
                var response = new
                {
                    valid = false,
                    message = "Email is required"
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("index", "Home");
        }

    }
}