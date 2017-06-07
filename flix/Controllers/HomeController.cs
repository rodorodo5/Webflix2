using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using flix.Models;
using flix.Models.Mongo;
using MongoDB.Bson;

namespace flix.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel()
            {
                LMovie = ConnectionDb.GetTopMovieReview(10),
                LGetTopUserReviewerses = ConnectionDb.GetTopUserReviewerses(10),
                LGetLastReviews = ConnectionDb.GetLastReviews(10),
                LMostPopularMovies = ConnectionDb.GetRankMovie(10),
                LActors = ConnectionDb.GetActors(),
                LGenres = ConnectionDb.GetGenres()
               
            };
            return View(viewModel);
        }

<<<<<<< HEAD
        //public ActionResult UserL()
        //{
        //    var viewModel = new UserL();
        //    return View(viewModel);
        //}


=======
        [HttpPost]
        public JsonResult Home(string Prefix)
        {
            var y = new MongoMovieDbHelper();
            List<MongoMovie> searchBars = new List<MongoMovie>();
            searchBars = y.nose(Prefix);
            //var x = (from N in searchBars where N.Title.StartsWith(search) select new {N.Title});
            return Json(searchBars, JsonRequestBehavior.AllowGet);
        }
>>>>>>> 0762f3d65594c5d05988379ccb37fb08d835a7f7
       
    }
}