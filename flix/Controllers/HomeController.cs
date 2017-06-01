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
                LMovie = ConnectionDb.GetTopMovieReview(10),
                LGetTopUserReviewerses = ConnectionDb.GetTopUserReviewerses(10),
                LGetLastReviews = ConnectionDb.GetLastReviews(10),
                LMostPopularMovies = ConnectionDb.GetRankMovie(10),
                LActors = ConnectionDb.GetActors(),
                LGenres = ConnectionDb.GetGenres()
            };
            return View(viewModel);
        }
    }
}