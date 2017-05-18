using flix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flix.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserRegister(FormCollection formCollection)
        {
            User userObj = new User();
            userObj.Username = formCollection["Username"];
            userObj.Password = formCollection["Password"];
            //userObj.insert(userObj);
            return View("RegSucces", userObj);

        }
    }
}