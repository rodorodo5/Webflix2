using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flix.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult review()
        {
            return View();
        }
    }
}