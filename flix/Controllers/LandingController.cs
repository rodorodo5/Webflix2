﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flix.Controllers
{
    public class LandingController : Controller
    {
        // GET: Landing
        [AllowAnonymous]
        public ActionResult Landing()
        {
            return View();
        }
    }
}