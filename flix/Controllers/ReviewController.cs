using flix.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace flix.Controllers
{
    public class ReviewController : Controller
    {


        public ActionResult Review(int id)
        {
            var movieActorDbHelper = new MovieActorDbHelper();
            var moviegenreDbHelper = new MovieGenreDBHelper();
            var posterDbHelper = new PosterDBHelper();
            var trailerDbHelper = new TrailerDBHelper();
            var movieData = new MovieDBHelper();
            var reviewData = new MongoMovieDbHelper();
            var viewModel = new MovieReviewsModel()
            {
                MovieActors = movieActorDbHelper.GetByMovieId(id),
                Genres = moviegenreDbHelper.GetByMovieId(id),
                Posters = posterDbHelper.GetByMovieId(id),
                Trailers = trailerDbHelper.GetByMovieId(id, 4),
                Movie = movieData.GetById(id),
                LReviews =  reviewData.GetReviews(id)
            };

        return View(viewModel);

        }

    }
}