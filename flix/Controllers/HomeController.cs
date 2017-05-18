using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using flix.Models;

namespace flix.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel()
            {
                Poster = new Poster(),
                LPoster = ConnectionDb.GetPosters(),
                Actor = new Actor(),
                LActors = ConnectionDb.GetActors(),
                Genre = new Genre(),
                LGenres = ConnectionDb.GetGenres()
            };
            return View(viewModel);
        }

   
    }
}