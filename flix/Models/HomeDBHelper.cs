using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public static class ConnectionDb
    {
        private static readonly string StrConnection = ConfigurationManager.ConnectionStrings["DBConnection"]
            .ConnectionString;
     

        public static List<Movie> GetTopMovieReview(int top)
        {
           
            List<Movie> movie = new List<Movie>();
            SqlConnection connection = new SqlConnection(StrConnection);
            string cmd = "GetTopMovies";
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@Top", SqlDbType.VarChar).Value = top.ToString();
            connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            while (dr.Read())
            {
                Movie r = new Movie();
                r.Id = long.Parse(dr["Id"].ToString());
                r.Title = dr["title"].ToString();
                movie.Add(r);
            }
            connection.Close();
            return movie;

        }
    
        public static List<Genre> GetGenres()
        {
            List<Genre> genre = new List<Genre>();
            SqlConnection connection = new SqlConnection(StrConnection);
            string cmd = "SELECT * from Genre";
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            while (dr.Read())
            {
                Genre g = new Genre();
                g.Id = long.Parse(dr["Id"].ToString());
                g.Name = dr["Name"].ToString();
                genre.Add(g);
            }
            connection.Close();
            return genre;
        }

        public static List<Actor> GetActors()
        {

            List<Actor> actors = new List<Actor>();
            //SqlConnection connection = new SqlConnection(StrConnection);
            //string cmd = "SELECT DISTINCT(Actor_Id) from Movie_Actor";
            //SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            //connection.Open();
            //SqlDataReader dr = sqlCmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    Actor a = new Actor();
            //    a.Id = long.Parse(dr["Id"].ToString());
            //    a.Name = dr["Name"].ToString();
            //    a.PathImage = dr["Path_Image"].ToString();
            //    actors.Add(a);
            //}
            return actors;
        }

        public static List<GetLastReviews> GetLastReviews(int top)
        {
            List<GetLastReviews> lastReviewses= new List<GetLastReviews>();
            SqlConnection connection = new SqlConnection(StrConnection);
            string cmd = "GetLastMovieReviews";
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@Top", SqlDbType.VarChar).Value = top.ToString();
            connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            while (dr.Read())
            {
                GetLastReviews getLasR = new GetLastReviews();
                getLasR.Id = long.Parse(dr["Id"].ToString());
                getLasR.Title = dr["Title"].ToString();
                getLasR.Path= dr["PathImage"].ToString();
                getLasR.Comment = dr["Comment"].ToString();
                getLasR.Date = DateTime.Parse(dr["Date"].ToString());
                lastReviewses.Add(getLasR);
            }
            connection.Close();
            return lastReviewses;

        }


        public static List<ReviewList> ReviewList(int top)
        {
            List<ReviewList> lastReviewses = new List<ReviewList>();
            SqlConnection connection = new SqlConnection(StrConnection);
            string cmd = "Review_GetList";
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@Top", SqlDbType.VarChar).Value = top.ToString();
            connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            while (dr.Read())
            {
                ReviewList getLasR = new ReviewList();
                getLasR.Id = long.Parse(dr["Id"].ToString());
                getLasR.User_Id = long.Parse(dr["User_Id"].ToString());
                getLasR.name = dr["name"].ToString();
                getLasR.Comment = dr["Comment"].ToString();
                getLasR.Date = DateTime.Parse(dr["Date"].ToString());
                lastReviewses.Add(getLasR);
            }
            connection.Close();
            return lastReviewses;

        }






        public static List<MostPopularMovie> GetRankMovie(int top)
        {
            List<MostPopularMovie> getRankMovie = new List<MostPopularMovie>();
            SqlConnection connection = new SqlConnection(StrConnection);
            string cmd = "GetRankMovie";
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@Top", SqlDbType.VarChar).Value = top.ToString();
            connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();
          
            while (dr.Read())
            {
                MostPopularMovie gtMostPopularMovie = new MostPopularMovie();
                gtMostPopularMovie.Id = long.Parse(dr["Id"].ToString());
                gtMostPopularMovie.Title = dr["Title"].ToString();
                gtMostPopularMovie.Path = dr["PathImage"].ToString();
                gtMostPopularMovie.Rank = char.Parse(dr["Calificacion"].ToString());
                getRankMovie.Add(gtMostPopularMovie);
            }
            connection.Close();
            return getRankMovie;

        }

        public static List<GetTopUserReviewers> GetTopUserReviewerses(int top)
        {
            List<GetTopUserReviewers> getTopUserReviewersesMovie = new List<GetTopUserReviewers>();
            SqlConnection connection = new SqlConnection(StrConnection);
            string cmd = "GetTopUserReviewer";
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@Top", SqlDbType.VarChar).Value = top.ToString();
            connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            while (dr.Read())
            {
                GetTopUserReviewers gtMostPopularMovie = new GetTopUserReviewers();
                gtMostPopularMovie.Id = long.Parse(dr["Id"].ToString());
                gtMostPopularMovie.Username = dr["Username"].ToString();
                gtMostPopularMovie.Reviews = int.Parse(dr["Reviews"].ToString());
                
                getTopUserReviewersesMovie.Add(gtMostPopularMovie);
            }
            connection.Close();
            return getTopUserReviewersesMovie;

        }

    }
}