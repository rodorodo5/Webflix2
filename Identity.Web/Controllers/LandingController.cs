using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Web.Controllers
{
    public class LandingController : Controller
    {
       [AllowAnonymous]
        public ActionResult Landing()
        {
            return View();
        }
    }
}