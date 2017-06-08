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