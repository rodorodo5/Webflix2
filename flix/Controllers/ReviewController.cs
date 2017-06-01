using flix.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flix.Controllers
{
    public class ReviewController : Controller
    {
        private static readonly string StrConnection = ConfigurationManager.ConnectionStrings["DBConnection"]
           .ConnectionString;
        // GET: Review
        public ActionResult review()
        {
            var viewModel = new Review()
            {
                Movie = new Movie(),

                LReviewList = ConnectionDb.ReviewList(5),
              
            };
            return View(viewModel);
     

        }
        [HttpPost]
        public ActionResult review(Models.Review rev)
        {
           
            using (SqlConnection con = new SqlConnection(StrConnection))
            {
                string query = "INSERT INTO Review VALUES (@Comment, @Rank, @Watched, @Wished, @Movie_Id, @User_Id, GETDATE());";
                query += " SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Comment", rev.Comment);
                    cmd.Parameters.AddWithValue("@Rank", rev.Rank);
                    cmd.Parameters.AddWithValue("@Watched", rev.Watched);
                    cmd.Parameters.AddWithValue("@Wished", rev.Wished);
                    cmd.Parameters.AddWithValue("@Movie_Id", rev.Movie.Id);
                    cmd.Parameters.AddWithValue("@User_Id", rev.User.Id);
                    rev.Id = Convert.ToInt64(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Review");
            }

            return View(rev);

        }

    }
}