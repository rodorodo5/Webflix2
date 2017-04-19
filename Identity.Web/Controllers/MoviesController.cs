using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Web.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [Authorize]
        public ActionResult Movies()
        {
            ViewBag.Message = "Your Movie page.";

            return View();
        }

    }
}