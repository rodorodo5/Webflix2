using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flix.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

      
  
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public ActionResult Login(User objUser)   
        {  
            if (ModelState.IsValid)   
            {  
                using(GoodMovie db = new GoodMovie())  
                {  
                    var obj = db.Users.Where(a => a.username.Equals(objUser.username) && a.password.Equals(objUser.password)).FirstOrDefault();  
                    if (obj != null)  
                    {  
                        Session["Id"] = obj.Id.ToString();  
                        Session["username"] = obj.username.ToString();  
                        return RedirectToAction("Index","Home");  
                    }  
                }  
            }  
            return View(objUser);  
        }
      

        public ActionResult Index()  
        {  
            if (Session["Id"] != null)  
            {  
                return View();  
            } else  
            {  
                return RedirectToAction("Index");  
            }  
        }


        public ActionResult logout()
        {
            Session.Abandon();
            Session["username"] = Session.Mode;
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Register()
        {
            return View();
        }
    }
}